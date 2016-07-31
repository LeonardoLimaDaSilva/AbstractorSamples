using System.Data.Entity.ModelConfiguration;
using AbstractorSamples.Web.Persistence.EntityFramework.Models;

namespace AbstractorSamples.Web.Persistence.EntityFramework.Configurations
{
    internal sealed class ItemModelConfiguration : EntityTypeConfiguration<ItemModel>
    {
        public ItemModelConfiguration()
        {
            ToTable("Item");
        }
    }
}