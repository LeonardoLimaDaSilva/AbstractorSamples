using System.Collections.Generic;
using AbstractorSamples.Domain.Items.Queries;

namespace AbstractorSamples.Domain.Items.Aggregates
{
    public interface IItemRepository
    {
        // Repositories interfaces should expose read-only methods
        // Do not expose methods that returns an IQueryable, it is an abstraction leak.
        // All processing operations, like pagination and ordering should be implemented inside the repository, 
        // and only already processed collections should be returned, e.g., IEnumerable, IList, ICollection, etc.
        IEnumerable<ItemDetail> GetAllItems();
    }
}