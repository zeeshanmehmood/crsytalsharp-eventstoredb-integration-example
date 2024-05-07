using System;

namespace CrystalSharpEventStoreDbIntegrationExample.Application.ReadModels
{
    public class ProductReadModel
    {
        public Guid GlobalUId { get; set; }
        public long Version { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public decimal? Price { get; set; }
    }
}
