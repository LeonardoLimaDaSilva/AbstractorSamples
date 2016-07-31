using System.Web.Http;
using Abstractor.Cqrs.Interfaces.Operations;

namespace AbstractorSamples.Web.Controllers
{
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