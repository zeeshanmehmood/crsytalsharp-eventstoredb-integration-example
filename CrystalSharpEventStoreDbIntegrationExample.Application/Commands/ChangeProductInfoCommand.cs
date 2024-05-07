using System;
using CrystalSharp.Application;
using CrystalSharpEventStoreDbIntegrationExample.Application.Responses;

namespace CrystalSharpEventStoreDbIntegrationExample.Application.Commands
{
    public class ChangeProductInfoCommand : ICommand<CommandExecutionResult<ProductResponse>>
    {
        public Guid GlobalUId { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
    }
}
