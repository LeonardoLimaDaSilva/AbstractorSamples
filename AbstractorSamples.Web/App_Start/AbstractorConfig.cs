using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Abstractor.Cqrs.AzureStorage.Extensions;
using Abstractor.Cqrs.EntityFramework.Extensions;
using Abstractor.Cqrs.Infrastructure.CompositionRoot;
using Abstractor.Cqrs.Infrastructure.CompositionRoot.Extensions;
using Abstractor.Cqrs.SimpleInjector.Adapters;
using Abstractor.Cqrs.UnitOfWork.Extensions;
using AbstractorSamples.Web.Persistence.AzureStorage;
using AbstractorSamples.Web.Persistence.EntityFramework;
using AbstractorSamples.Web.Persistence.EntityFramework.Contexts;
using SimpleInjector;
using SimpleInjector.Extensions.LifetimeScoping;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;

namespace AbstractorSamples.Web
{
    /// <summary>
    ///     Application composition root.
    /// </summary>
    public static class AbstractorConfig
    {
        private static Container _container;

        /// <summary>
        ///     Singleton instance of Simple Injector
        /// </summary>
        public static Container Container => _container ?? (_container = new Container());

        /// <summary>
        ///     Registers the Abstractor framework and all application concrete implementations.
        /// </summary>
        /// <param name="httpConfiguration"></param>
        public static void Register(HttpConfiguration httpConfiguration)
        {
            // Defines a hybrid scope for the ScopedLifestyle that supports ASP.NET MVC and Web API
            Container.Options.DefaultScopedLifestyle = Lifestyle.CreateHybrid(() =>
                Container.GetCurrentLifetimeScope() != null,
                new LifetimeScopeLifestyle(),
                new WebApiRequestLifestyle());

            var applicationAssemblies = GetApplicationAssemblies().ToList();

            // Discovers all the concrete types of the application which the type name ends with the following words
            var applicationTypes = applicationAssemblies
                .GetImplementations(ImplementationConvention.NameEndsWith,
                    new[]
                    {
                        "Service",
                        "Factory",
                        "Facade",
                        "Repository"
                    }
                );

            // Builds the adapter provided by the "Abstractor.Cqrs.SimpleInjector" module
            var containerAdapter = new ContainerAdapter(Container);
            
            containerAdapter.RegisterAbstractor(settings =>
            {
                settings.ApplicationAssemblies = applicationAssemblies;
                settings.ApplicationTypes = applicationTypes;
            });

            CustomRegistrations();
            
            // Registers the Entity Framework integration module
            containerAdapter.RegisterEntityFramework<ApplicationDbContext>();

            // Registers the Azure Cloud Storage integration module
            //containerAdapter.RegisterAzureBlob<ApplicationBlobContext>();
            //containerAdapter.RegisterAzureQueue<ApplicationQueueContext>();
            //containerAdapter.RegisterAzureTable<ApplicationTableContext>();

            // Registers the Unit of Work module, that synchronizes all the contexts registered above
            //containerAdapter.RegisterUnitOfWork();

            Container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            Container.RegisterMvcIntegratedFilterProvider();
            Container.Verify();

            // Defines the ASP.NET MVC dependency resolver
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(Container));

            // Defines the ASP.NET Web API dependency resolver
            httpConfiguration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(Container);
        }

        /// <summary>
        ///     Registers application custom implementations
        /// </summary>
        private static void CustomRegistrations()
        {
            // Overrides the default empty logger used by the framework
            //Container.Register<ILogger, DebugOutputLogger>(Lifestyle.Singleton);

            // Overrides the default system clock provided by the framework
            //Container.Register<IClock, UtcClock>(Lifestyle.Singleton);
        }

        private static IEnumerable<Assembly> GetApplicationAssemblies()
        {
            // In this sample all the implementations are defined in the same assembly, separated only by namespaces
            return new[] {Assembly.GetExecutingAssembly()};

            // It is a best practice to define infrastructural implementations in separate assemblies
            // e.g.:
            //return new[]
            //{
            //    Assembly.Load("MyApplication.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"),
            //    Assembly.Load("MyApplication.Persistence.EntityFramework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"),
            //    Assembly.Load("MyApplication.Persistence.AzureStorage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")
            //};
        }
    }
}