using Abstractor.Cqrs.Interfaces.Events;
using AbstractorSamples.Web.Domain.Items.Aggregates;

namespace AbstractorSamples.Web.Domain.Items.Events
{
    // Events should be named in the past tense as they represent actions that have already occurred.
    public class ItemCreated : IDomainEvent
    {
        // Events should have the minimal necessary properties for the processing.
        public ItemId ItemId { get; }

        public string Name { get; }
        // By definition Domain Events should be immutable.

        public ItemCreated(ItemId itemId, string name)
        {
            ItemId = itemId;
            Name = name;
        }
    }
}