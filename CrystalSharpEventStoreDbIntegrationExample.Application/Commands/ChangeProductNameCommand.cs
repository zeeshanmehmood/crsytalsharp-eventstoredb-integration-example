using System;
using CrystalSharp.Application;
using CrystalSharpEventStoreDbIntegrationExample.Application.Responses;

namespace CrystalSharpEventStoreDbIntegrationExample.Application.Commands
{
    public class ChangeProductNameCommand : ICommand<CommandExecutionResult<ProductResponse>>
    {
        public Guid GlobalUId { get; set; }
        public string Name { get; set; }
    }
}
