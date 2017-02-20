using System.Collections.Generic;
using Abstractor.Cqrs.Interfaces.Operations;

namespace AbstractorSamples.Domain.Items.Queries
{
    // Defines a query and its corresponding result.
    public class GetAllItems : IQuery<IEnumerable<ItemDetail>>
    {
    }

    // Defines a query and its corresponding result.
}