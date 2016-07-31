using System;
using Abstractor.Cqrs.Interfaces.Domain;

namespace AbstractorSamples.Web.Persistence.EntityFramework.Models
{
    // Only classes marked as an aggregate root can be persisted via repositories
    public class ItemModel : IAggregateRoot
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}