using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Abstractor.Cqrs.EntityFramework.Interfaces;
using Abstractor.Cqrs.Interfaces.Events;
using Abstractor.Cqrs.Interfaces.Operations;
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
        IDomainEventHandler<ItemDeleted>,
        IQueryHandler<GetAllItems, IEnumerable<ItemDetail>> // If desired, a repository can be implemented as a query handler, without the intermediation of the IItemRepository interface
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
            // You can delete creating a detached entity with the primary key 
            var detachedEntity = new ItemModel {Id = domainEvent.ItemId.Value};
            _repository.Delete(detachedEntity);

            // Or getting it first and passing the entire object as example below:
            //var attachedEntity  = _repository.Get(domainEvent.ItemId.Value);
            //_repository.Delete(attachedEntity);
        }

        public void Handle(ItemUpdated domainEvent)
        {
            // You can change an attached entity directly
            var attachedEntity = _repository.Query().Single(i => i.Id == domainEvent.ItemId.Value);
            attachedEntity.Name = domainEvent.NewName;

            // Or creating and detached entity and passing it to the Update repository method as example below:
            //var detachedEntity = new ItemModel
            //{
            //    Id = domainEvent.ItemId.Value,
            //    Name = domainEvent.NewName
            //};

            //_repository.Update(detachedEntity);
        }

        public IEnumerable<ItemDetail> GetAllItems()
        {
            // Do not expose methods that returns an IQueryable, it is an abstraction leak.
            // All processing operations, like pagination and ordering should be implemented inside the repository, 
            // and only already processed collections should be returned, e.g., IEnumerable, IList, ICollection, etc.

            // The query methods should be optimized for each use case, returning only tailored, flattened and denormalized data transfer objects.
            return _repository.Query().AsNoTracking().ToList().Select(i => i.ToItemDetail());
        }

        // Example of repository being implemented as a query handler directly. In this way there is no need for an IItemRepository interface.
        public IEnumerable<ItemDetail> Handle(GetAllItems query)
        {
            return _repository.Query().AsNoTracking().ToList().Select(i => i.ToItemDetail());
        }
    }
}