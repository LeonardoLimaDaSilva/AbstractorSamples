using System;
using Abstractor.Cqrs.Interfaces.Domain;

namespace AbstractorSamples.Persistence.EntityFramework.Models
{
    // Only classes marked as an aggregate root can be persisted via repositories.
    // All dependent entities associations and collections should be handled via the aggregate root.
    public class ItemModel : IAggregateRoot
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}