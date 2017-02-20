using System;

namespace AbstractorSamples.Domain.Items.Queries
{
    // Result of a query. It should be a flattened and denormalized data transfer object, tailored for each use case.
    public class ItemDetail
    {
        public DateTime CreationDate { get; set; }

        public Guid ItemId { get; set; }

        public string Name { get; set; }
    }
}