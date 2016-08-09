using System;
using AbstractorSamples.Domain.Items.Aggregates;

namespace AbstractorSamples.Domain.Items.Queries
{
    // Result of a query. It should be a flattened and denormalized data transfer object, tailored for each use case.
    public class ItemDetail
    {
        public ItemId ItemId { get; }

        public string Name { get; }

        public DateTime CreationDate { get; }

        public ItemDetail(
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