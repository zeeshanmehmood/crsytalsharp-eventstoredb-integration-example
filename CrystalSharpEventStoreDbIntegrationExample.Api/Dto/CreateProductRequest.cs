namespace CrystalSharpEventStoreDbIntegrationExample.Api.Dto
{
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
    }
}
