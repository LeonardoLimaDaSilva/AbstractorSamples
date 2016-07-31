using System.Web.Http;
using AbstractorSamples.Web.Domain.Items.Commands;

namespace AbstractorSamples.Web.Controllers
{
    public class ItemController : BaseApiController
    {
        [HttpPost]
        public void Post(CreateItem command)
        {
            // Following this pattern, the controllers actions have the only responsibility of dispatching 
            // commands and other concerns like identity authorization.

            // Dispatches the CreateItem command to the CreateItemHandler.
            // The framework discovers the class that implements the ICommandHandler<CreateItem> interface.
            CommandDispatcher.Dispatch(command);
        }
    }
}
