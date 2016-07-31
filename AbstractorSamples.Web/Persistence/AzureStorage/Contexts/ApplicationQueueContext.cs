using Abstractor.Cqrs.AzureStorage.Queue;

namespace AbstractorSamples.Web.Persistence.AzureStorage.Contexts
{
    public class ApplicationQueueContext : AzureQueueContext
    {
        public ApplicationQueueContext()
            : base("ApplicationAzureStorageConnectionString")
        {
        }
    }
}