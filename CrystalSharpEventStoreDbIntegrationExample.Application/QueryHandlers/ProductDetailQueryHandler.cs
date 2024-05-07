using System.Threading;
using System.Threading.Tasks;
using CrystalSharp.Application;
using CrystalSharp.Application.Handlers;
using CrystalSharp.Infrastructure.EventStoresPersistence;
using CrystalSharpEventStoreDbIntegrationExample.Application.Domain.Aggregates.ProductAggregate;
using CrystalSharpEventStoreDbIntegrationExample.Application.Queries;
using CrystalSharpEventStoreDbIntegrationExample.Application.ReadModels;

namespace CrystalSharpEventStoreDbIntegrationExample.Application.QueryHandlers
{
    public class ProductDetailQueryHandler : QueryHandler<ProductDetailQuery, ProductReadModel>
    {
        private readonly IAggregateEventStore<int> _eventStore;

        public ProductDetailQueryHandler(IAggregateEventStore<int> eventStore)
        {
            _eventStore = eventStore;
        }

        public override async Task<QueryExecutionResult<ProductReadModel>> Handle(ProductDetailQuery request, CancellationToken cancellationToken = default)
        {
            if (request == null) return await Fail("Invalid query.");

            Product product = await _eventStore.Get<Product>(request.GlobalUId, cancellationToken).ConfigureAwait(false);

            if (product == null)
            {
                return await Fail("Product not found.");
            }

            ProductReadModel readModel = new()
            {
                GlobalUId = product.GlobalUId,
                Name = product.Name,
                Sku = product.ProductInfo?.Sku,
                Price = product.ProductInfo?.Price,
                Version = product.Version
            };

            return await Ok(readModel);
        }
    }
}
