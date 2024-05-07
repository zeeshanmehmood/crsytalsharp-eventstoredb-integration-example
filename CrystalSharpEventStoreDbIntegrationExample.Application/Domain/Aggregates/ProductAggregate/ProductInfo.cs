using System;
using System.Collections.Generic;
using CrystalSharp.Domain;

namespace CrystalSharpEventStoreDbIntegrationExample.Application.Domain.Aggregates.ProductAggregate
{
    public class ProductInfo : ValueObject
    {
        public string Sku { get; private set; }
        public decimal Price { get; private set; }

        public ProductInfo(string sku, decimal price)
        {
            Sku = sku;
            Price = price;
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Sku;
            yield return Price;
        }
    }
}
