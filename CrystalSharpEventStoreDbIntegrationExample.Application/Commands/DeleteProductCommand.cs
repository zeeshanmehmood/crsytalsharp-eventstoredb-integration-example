using System;
using CrystalSharp.Application;
using CrystalSharpEventStoreDbIntegrationExample.Application.Responses;

namespace CrystalSharpEventStoreDbIntegrationExample.Application.Commands
{
    public class DeleteProductCommand : ICommand<CommandExecutionResult<DeleteProductResponse>>
    {
        public Guid GlobalUId { get; set; }
    }
}
