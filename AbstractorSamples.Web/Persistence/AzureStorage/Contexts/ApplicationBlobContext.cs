using Abstractor.Cqrs.AzureStorage.Blob;

namespace AbstractorSamples.Web.Persistence.AzureStorage.Contexts
{
    public class ApplicationBlobContext : AzureBlobContext
    {
        public ApplicationBlobContext()
            : base("ApplicationAzureStorageConnectionString")
        {
        }
    }
}