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
    public class ChangeProductNameCommandHandler : CommandHandler<ChangeProductNameCommand, ProductResponse>
    {
        private readonly IAggregateEventStore<int> _eventStore;

        public ChangeProductNameCommandHandler(IAggregateEventStore<int> eventStore)
        {
            _eventStore = eventStore;
        }

        public override async Task<CommandExecutionResult<ProductResponse>> Handle(ChangeProductNameCommand request, CancellationToken cancellationToken = default)
        {
            if (request == null) return await Fail("Invalid command.");

            Product existingProduct = await _eventStore.Get<Product>(request.GlobalUId, cancellationToken).ConfigureAwait(false);

            if (existingProduct == null)
            {
                await Fail("Product not found.");
            }

            existingProduct.ChangeName(request.Name);
            await _eventStore.Store(existingProduct, cancellationToken).ConfigureAwait(false);

            ProductResponse response = new() { GlobalUId = existingProduct.GlobalUId, Name = existingProduct.Name };

            return await Ok(response);
        }
    }
}
