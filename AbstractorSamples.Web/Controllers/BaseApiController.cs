using System.Web.Http;
using Abstractor.Cqrs.Interfaces.Operations;

namespace AbstractorSamples.Web.Controllers
{
    // Convenience base class that exposes the command and query dispatchers for all controllers that implements it.
    // If one prefers, it's possible to inject the interfaces normally via constructor dependency injection.
    public class BaseApiController : ApiController
    {
        protected readonly ICommandDispatcher CommandDispatcher;
        protected readonly IQueryDispatcher QueryDispatcher;

        public BaseApiController()
        {
            CommandDispatcher = AbstractorConfig.Container.GetInstance<ICommandDispatcher>();
            QueryDispatcher = AbstractorConfig.Container.GetInstance<IQueryDispatcher>();
        }
    }
}