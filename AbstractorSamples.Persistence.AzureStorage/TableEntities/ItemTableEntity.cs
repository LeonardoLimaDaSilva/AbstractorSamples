using System;
using Abstractor.Cqrs.AzureStorage.Attributes;
using AbstractorSamples.Domain.Items.Events;
using AbstractorSamples.Domain.Items.Queries;
using Microsoft.WindowsAzure.Storage.Table;

namespace AbstractorSamples.Persistence.AzureStorage.TableEntities
{
    [AzureTable("ItemTableEntity")]
    public class ItemTableEntity : TableEntity
    {
        public DateTime CreationDate { get; set; }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public static ItemTableEntity FromItemCreated(ItemCreated itemCreated)
        {
            return new ItemTableEntity
            {
                RowKey = itemCreated.ItemId.ToString(),
                Id = itemCreated.ItemId.Value,
                Name = itemCreated.Name,
                CreationDate = itemCreated.CreationDate
            };
        }

        public ItemDetail ToItemDetail()
        {
            return new ItemDetail
            {
                CreationDate = CreationDate,
                Name = Name,
                ItemId = Id
            };
        }
    }
}