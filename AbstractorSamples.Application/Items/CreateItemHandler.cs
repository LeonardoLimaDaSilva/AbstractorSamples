using System.Collections.Generic;
using Abstractor.Cqrs.Interfaces.Events;
using Abstractor.Cqrs.Interfaces.Operations;
using AbstractorSamples.Domain.Items.Aggregates;
using AbstractorSamples.Domain.Items.Commands;

namespace AbstractorSamples.Application.Items
{
    public class CreateItemHandler : ICommandHandler<CreateItem>
    {
        // The command handlers can receive any service or repository via constructor dependency injection.
        // It's a good practice that repositories interfaces injected into the command handlers have read-only operations, 
        // all the write operations should be performed via domain events emission and omitted from the public interfaces.
        public IEnumerable<IDomainEvent> Handle(CreateItem command)
        {
            var item = new Item(ItemId.New());

            item.Create(command.Name);

            // The events emitted by the aggregate root will be processed synchronously by the framework and dispatched to all interested parties.
            return item.EmittedEvents;
        }
    }
}