using System.Collections.Generic;
using AbstractorSamples.Domain.Items.Commands;
using AbstractorSamples.Domain.Items.Queries;

namespace AbstractorSamples.Web.Controllers
{
    // Following this pattern, the controllers actions have the only responsibility of dispatching 
    // commands and other concerns like identity authorization, or model conversions.
    public class ItemController : BaseApiController
    {
        public IEnumerable<ItemDetail> Get()
        {
            var query = new GetAllItems();
            // Dispatches the GetAllItems to the ItemRepository.
            // The framework discovers the class that implements the IQueryHandler<GetAllItems, IEnumerable<ItemDetail>> interface.
            return QueryDispatcher.Dispatch(query);
        }
        
        public void Post(CreateItem command)
        {

            // Dispatches the CreateItem command to the CreateItemHandler.
            // The framework discovers the class that implements the ICommandHandler<CreateItem> interface.
            CommandDispatcher.Dispatch(command);
        }
    }
}