using Abstractor.Cqrs.AzureStorage.Blob;

namespace AbstractorSamples.Persistence.AzureStorage.Contexts
{
    public class ApplicationBlobContext : AzureBlobContext
    {
        public ApplicationBlobContext()
            : base("ApplicationAzureStorageConnectionString")
        {
        }
    }
}