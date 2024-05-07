using System.Threading;
using System.Threading.Tasks;
using CrystalSharp.Domain.Infrastructure;
using CrystalSharpEventStoreDbIntegrationExample.Application.Domain.Aggregates.ProductAggregate.Events;

namespace CrystalSharpEventStoreDbIntegrationExample.Application.EventHandlers
{
    public class ProductCreatedDomainEventHandler : ISynchronousDomainEventHandler<ProductCreatedDomainEvent>
    {
        public async Task Handle(ProductCreatedDomainEvent notification, CancellationToken cancellationToken = default)
        {
            //
        }
    }
}
