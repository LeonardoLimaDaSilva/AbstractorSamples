using Abstractor.Cqrs.AzureStorage.Queue;

namespace AbstractorSamples.Persistence.AzureStorage.Contexts
{
    public class ApplicationQueueContext : AzureQueueContext
    {
        public ApplicationQueueContext()
            : base("ApplicationAzureStorageConnectionString")
        {
        }
    }
}