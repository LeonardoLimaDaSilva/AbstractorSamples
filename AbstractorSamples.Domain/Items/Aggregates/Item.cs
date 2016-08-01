using Abstractor.Cqrs.Infrastructure.Domain;
using AbstractorSamples.Domain.Items.Events;

namespace AbstractorSamples.Domain.Items.Aggregates
{
    public class Item : AggregateRoot<ItemId>
    {
        // Aggregate roots should be loaded from the repository with minimal data, required only for business logic validation.
        public Item(ItemId id)
            : base(id)
        {
        }

        public void Create(string name)
        {
            // The aggregate behaviours are totally decoupled from infrastructural concerns.
            // The emitted events represents an intention of an operation that is already validated by the business logic.
            // All the events emitted inside an aggregate will be stored for future processing.
            Emit(new ItemCreated(Id, name));
        }
    }
}