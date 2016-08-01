using System.Data.Entity.ModelConfiguration;
using AbstractorSamples.Persistence.EntityFramework.Models;

namespace AbstractorSamples.Persistence.EntityFramework.Configurations
{
    internal sealed class ItemModelConfiguration : EntityTypeConfiguration<ItemModel>
    {
        public ItemModelConfiguration()
        {
            ToTable("Item");
        }
    }
}