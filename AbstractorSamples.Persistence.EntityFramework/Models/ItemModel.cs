using System;
using Abstractor.Cqrs.Interfaces.Domain;
using AbstractorSamples.Domain.Items.Aggregates;
using AbstractorSamples.Domain.Items.Events;
using AbstractorSamples.Domain.Items.Queries;

namespace AbstractorSamples.Persistence.EntityFramework.Models
{
    // Only classes marked as an aggregate root can be persisted via repositories.
    // All dependent entities associations and collections should be handled via the aggregate root.
    public class ItemModel : IAggregateRoot
    {
        public DateTime CreationDate { get; set; }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public static ItemModel FromItemCreated(ItemCreated itemCreated)
        {
            return new ItemModel
            {
                Id = itemCreated.ItemId.Value,
                Name = itemCreated.Name,
                CreationDate = itemCreated.CreationDate
            };
        }

        public ItemDetail ToItemDetail()
        {
            return new ItemDetail(
                new ItemId(Id),
                Name,
                CreationDate);
        }
    }
}