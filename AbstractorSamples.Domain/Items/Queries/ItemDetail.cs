namespace AbstractorSamples.Domain.Items.Queries
{
    // Result of a query. It should be a flattened and denormalized data transfer object, tailored for each use case.
    public class ItemDetail
    {
        public string Name { get; }

        public ItemDetail(string name)
        {
            Name = name;
        }
    }
}