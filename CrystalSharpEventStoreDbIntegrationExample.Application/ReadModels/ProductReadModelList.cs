using System.Collections.Generic;

namespace CrystalSharpEventStoreDbIntegrationExample.Application.ReadModels
{
    public class ProductReadModelList
    {
        public IEnumerable<ProductReadModel> Products { get; set; }
    }
}
