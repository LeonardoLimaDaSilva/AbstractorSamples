using Abstractor.Cqrs.AzureStorage.Table;

namespace AbstractorSamples.Persistence.AzureStorage.Contexts
{
    public class ApplicationTableContext : AzureTableContext
    {
        public ApplicationTableContext()
            : base("ApplicationAzureStorageConnectionString")
        {
        }
    }
}
