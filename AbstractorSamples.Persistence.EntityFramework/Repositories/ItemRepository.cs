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
        IDomainEventHandler<ItemCreated>, // Defines the repository as an observer of domain events
        IDomainEventHandler<ItemUpdated>,
        IDomainEventHandler<ItemDeleted>
    {
        private readonly IEntityFrameworkRepository<ItemModel> _repository;

        public ItemRepository(IEntityFrameworkRepository<ItemModel> repository)
        {
            _repository = repository;
        }

        public void Handle(ItemCreated domainEvent)
        {
            // The repository's single responsibility is to read the domain event and persist into the database
            _repository.Create(ItemModel.FromItemCreated(domainEvent));
        }

        public void Handle(ItemDeleted domainEvent)
        {
            // You can delete creating a detached entity with the primary key or getting it first and passing the entire object
            _repository.Delete(new ItemModel {Id = domainEvent.ItemId.Value});
        }

        public void Handle(ItemUpdated domainEvent)
        {
            // You can change an attached entity directly or creating and detached entity and passing it to the Update repository method
            var item = _repository.Query().Single(i => i.Id == domainEvent.ItemId.Value);
            item.Name = domainEvent.NewName;
        }

        public IEnumerable<ItemDetail> GetAllItems()
        {
            // Do not expose methods that returns an IQueryable, it is an abstraction leak.
            // All processing operations, like pagination and ordering should be implemented inside the repository, 
            // and only already processed collections should be returned, e.g., IEnumerable, IList, ICollection, etc.

            // The query methods should be optimized for each use case, returning only tailored, flattened and denormalized data transfer objects.
            return _repository.Query().AsNoTracking().ToList().Select(i => i.ToItemDetail());
        }
    }
}