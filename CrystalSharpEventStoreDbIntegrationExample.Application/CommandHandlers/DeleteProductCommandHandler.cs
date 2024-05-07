using System.Threading;
using System.Threading.Tasks;
using CrystalSharp.Application;
using CrystalSharp.Application.Handlers;
using CrystalSharp.Infrastructure.EventStoresPersistence;
using CrystalSharpEventStoreDbIntegrationExample.Application.Commands;
using CrystalSharpEventStoreDbIntegrationExample.Application.Domain.Aggregates.ProductAggregate;
using CrystalSharpEventStoreDbIntegrationExample.Application.Responses;

namespace CrystalSharpEventStoreDbIntegrationExample.Application.CommandHandlers
{
    public class DeleteProductCommandHandler : CommandHandler<DeleteProductCommand, DeleteProductResponse>
    {
        private readonly IAggregateEventStore<int> _eventStore;

        public DeleteProductCommandHandler(IAggregateEventStore<int> eventStore)
        {
            _eventStore = eventStore;
        }

        public override async Task<CommandExecutionResult<DeleteProductResponse>> Handle(DeleteProductCommand request, CancellationToken cancellationToken = default)
        {
            if (request == null) return await Fail("Invalid command.");

            Product existingProduct = await _eventStore.Get<Product>(request.GlobalUId, cancellationToken).ConfigureAwait(false);

            if (existingProduct == null)
            {
                await Fail("Product not found.");
            }

            await _eventStore.Delete<Product>(request.GlobalUId, cancellationToken).ConfigureAwait(false);

            DeleteProductResponse response = new() { GlobalUId = existingProduct.GlobalUId };

            return await Ok(response);
        }
    }
}
