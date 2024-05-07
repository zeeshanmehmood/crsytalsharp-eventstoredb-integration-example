using System;
using CrystalSharp.Application;
using CrystalSharpEventStoreDbIntegrationExample.Application.ReadModels;

namespace CrystalSharpEventStoreDbIntegrationExample.Application.Queries
{
    public class ProductDetailByVersionQuery : IQuery<QueryExecutionResult<ProductReadModel>>
    {
        public Guid GlobalUId { get; set; }
        public long Version { get; set; }
    }
}
