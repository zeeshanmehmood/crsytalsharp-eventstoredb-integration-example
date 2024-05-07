using System;
using CrystalSharp.Application;
using CrystalSharpEventStoreDbIntegrationExample.Application.ReadModels;

namespace CrystalSharpEventStoreDbIntegrationExample.Application.Queries
{
    public class ProductDetailQuery : IQuery<QueryExecutionResult<ProductReadModel>>
    {
        public Guid GlobalUId { get; set; }
    }
}
