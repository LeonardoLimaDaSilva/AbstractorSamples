using System;
using System.Collections.Generic;
using Abstractor.Cqrs.Infrastructure.Domain;

namespace AbstractorSamples.Web.Domain.Items.Aggregates
{
    public class ItemId : ValueObject<ItemId>
    {
        // By definition value objects should be immutable. All properties should be read only.
        public Guid Value { get; }

        public ItemId(Guid value)
        {
            Value = value;
        }

        // Factory method for value object creation.
        public static ItemId New()
        {
            return new ItemId(Guid.NewGuid());
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            // An value object is considered equal to another instance if all attributes are equal
            // So, you should return all properties of the value object to be included in equality check.
            yield return Value;
        }
    }
}