using System;
using Newtonsoft.Json;
using CrystalSharp.Domain.Infrastructure;

namespace CrystalSharpEventStoreDbIntegrationExample.Application.Domain.Aggregates.ProductAggregate.Events
{
    public class ProductCreatedDomainEvent : DomainEvent
    {
        public string Name { get; set; }
        public ProductInfo ProductInfo { get; set; }

        public ProductCreatedDomainEvent(Guid streamId, string name, ProductInfo productInfo)
        {
            StreamId = streamId;
            Name = name;
            ProductInfo = productInfo;
        }

        [JsonConstructor]
        public ProductCreatedDomainEvent(Guid streamId,
            string name,
            ProductInfo productInfo,
            int entityStatus,
            DateTime createdOn,
            DateTime? modifiedOn,
            long version)
        {
            StreamId = streamId;
            Name = name;
            ProductInfo = productInfo;
            EntityStatus = entityStatus;
            CreatedOn = createdOn;
            ModifiedOn = modifiedOn;
            Version = version;
        }
    }
}
