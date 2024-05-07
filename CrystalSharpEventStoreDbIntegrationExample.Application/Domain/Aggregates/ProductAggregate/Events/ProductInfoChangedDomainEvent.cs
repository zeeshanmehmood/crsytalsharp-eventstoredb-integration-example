﻿using System;
using Newtonsoft.Json;
using CrystalSharp.Domain.Infrastructure;

namespace CrystalSharpEventStoreDbIntegrationExample.Application.Domain.Aggregates.ProductAggregate.Events
{
    public class ProductInfoChangedDomainEvent : DomainEvent
    {
        public ProductInfo ProductInfo { get; set; }

        public ProductInfoChangedDomainEvent(Guid streamId, ProductInfo productInfo)
        {
            StreamId = streamId;
            ProductInfo = productInfo;
        }

        [JsonConstructor]
        public ProductInfoChangedDomainEvent(Guid streamId,
            ProductInfo productInfo,
            int entityStatus,
            DateTime? modifiedOn,
            long version)
        {
            StreamId = streamId;
            ProductInfo = productInfo;
            EntityStatus = entityStatus;
            ModifiedOn = modifiedOn;
            Version = version;
        }
    }
}
