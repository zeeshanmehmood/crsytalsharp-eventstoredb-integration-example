using System.Threading;
using System.Threading.Tasks;
using CrystalSharp.Domain.Infrastructure;
using CrystalSharpEventStoreDbIntegrationExample.Application.Domain.Aggregates.ProductAggregate.Events;

namespace CrystalSharpEventStoreDbIntegrationExample.Application.EventHandlers
{
    public class ProductNameChangedDomainEventHandler : ISynchronousDomainEventHandler<ProductNameChangedDomainEvent>
    {
        public async Task Handle(ProductNameChangedDomainEvent notification, CancellationToken cancellationToken = default)
        {
            //
        }
    }
}
