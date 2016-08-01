using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Abstractor.Cqrs.EntityFramework.Interfaces;
using Abstractor.Cqrs.Interfaces.Events;
using AbstractorSamples.Domain.Items.Aggregates;
using AbstractorSamples.Domain.Items.Events;
using AbstractorSamples.Domain.Items.Queries;
using AbstractorSamples.Persistence.EntityFramework.Models;

namespace AbstractorSamples.Persistence.EntityFramework.Repositories
{
    public class ItemRepository :
        IItemRepository,
        IDomainEventHandler<ItemCreated> // Defines the repository as an observer of the ItemCreated domain event
    {
        private readonly IEntityFrameworkRepository<ItemModel> _repository;

        public ItemRepository(IEntityFrameworkRepository<ItemModel> repository)
        {
            _repository = repository;
        }

        public void Handle(ItemCreated domainEvent)
        {
            // The repository's single responsibility is to read the domain event and persist into the database
            _repository.Create(
                new ItemModel
                {
                    Id = domainEvent.ItemId.Value,
                    Name = domainEvent.Name
                });
        }

        public IEnumerable<ItemDetail> GetAllItems()
        {
            // Do not expose methods that returns an IQueryable, it is an abstraction leak.
            // All processing operations, like pagination and ordering should be implemented inside the repository, 
            // and only already processed collections should be returned, e.g., IEnumerable, IList, ICollection, etc.

            // The query methods should be optimized for each use case, returning only tailored, flattened and denormalized data transfer objects.
            return _repository.Query().AsNoTracking().ToList().Select(i => new ItemDetail(i.Name));
        }
    }
}