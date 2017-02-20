using System.Collections.Generic;
using Abstractor.Cqrs.Interfaces.Operations;

namespace AbstractorSamples.Domain.Items.Queries
{
    public class GetAllItemsFromTable : IQuery<IEnumerable<ItemDetail>>
    {
    }
}