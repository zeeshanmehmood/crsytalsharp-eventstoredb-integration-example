using CrystalSharp.Application;
using CrystalSharpEventStoreDbIntegrationExample.Application.Responses;

namespace CrystalSharpEventStoreDbIntegrationExample.Application.Commands
{
    public class CreateProductCommand : ICommand<CommandExecutionResult<ProductResponse>>
    {
        public string Name { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
    }
}
