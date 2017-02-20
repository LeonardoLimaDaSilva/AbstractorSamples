using System;
using Abstractor.Cqrs.Interfaces.Events;
using AbstractorSamples.Domain.Items.Aggregates;

namespace AbstractorSamples.Domain.Items.Events
{
    // Events should be named in the past tense as they represent actions that have already occurred.
    public class ItemCreated : IDomainEvent
    {
        public DateTime CreationDate { get; }

        // Events should have the minimal necessary properties for the processing.
        // By definition Domain Events should be immutable.
        public ItemId ItemId { get; }

        public string Name { get; }

        public ItemCreated(
            ItemId itemId,
            string name,
            DateTime creationDate)
        {
            ItemId = itemId;
            Name = name;
            CreationDate = creationDate;
        }
    }
}