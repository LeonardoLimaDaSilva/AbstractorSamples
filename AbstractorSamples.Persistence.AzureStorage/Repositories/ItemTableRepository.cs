using System.Collections.Generic;
using System.Linq;
using Abstractor.Cqrs.AzureStorage.Interfaces;
using Abstractor.Cqrs.Interfaces.Events;
using AbstractorSamples.Domain.Items.Events;
using AbstractorSamples.Domain.Items.Queries;
using AbstractorSamples.Persistence.AzureStorage.TableEntities;

namespace AbstractorSamples.Persistence.AzureStorage.Repositories
{
    internal sealed class ItemTableRepository :
        IDomainEventHandler<ItemCreated>,
        IDomainEventHandler<ItemUpdated>,
        IDomainEventHandler<ItemDeleted>
    {
        private readonly IAzureTableRepository<ItemTableEntity> _repository;

        public ItemTableRepository(IAzureTableRepository<ItemTableEntity> repository)
        {
            _repository = repository;
        }

        public void Handle(ItemCreated domainEvent)
        {
            _repository.Save(ItemTableEntity.FromItemCreated(domainEvent));
        }

        public void Handle(ItemDeleted domainEvent)
        {
            var entity = _repository.Get(domainEvent.ItemId.ToString());
            _repository.Delete(entity);
        }

        public void Handle(ItemUpdated domainEvent)
        {
            var entity = _repository.Get(domainEvent.ItemId.ToString());
            entity.Name = domainEvent.NewName;
            _repository.Save(entity);
        }

        public IEnumerable<ItemDetail> GetAllItems()
        {
            var entities = _repository.GetAll();
            return entities.ToList().Select(e => e.ToItemDetail());
        }
    }
}