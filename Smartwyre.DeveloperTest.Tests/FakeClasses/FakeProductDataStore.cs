using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;

namespace Smartwyre.DeveloperTest.Tests.FakeClasses
{
    public class FakeProductDataStore : IProductDataStore
    {
        private readonly Dictionary<string, Product> _products;

        public FakeProductDataStore()
        {
            _products = new Dictionary<string, Product>
            {
                { "PRD-1", new Product() { Id = 1, Identifier = "PRD-1", Price = 17.5m, SupportedIncentives = SupportedIncentiveType.AmountPerUom, Uom = "" } },
                { "PRD-2", new Product() { Id = 2, Identifier = "PRD-2", Price = 10m, SupportedIncentives = SupportedIncentiveType.FixedCashAmount, Uom = "" } },
                { "PRD-3", new Product() { Id = 3, Identifier = "PRD-3", Price = 25m, SupportedIncentives = SupportedIncentiveType.FixedRateRebate, Uom = "" } },
                { "PRD-4", new Product() { Id = 4, Identifier = "PRD-4", Price = 125.50m, SupportedIncentives = SupportedIncentiveType.FixedCashAmount | SupportedIncentiveType.FixedRateRebate, Uom = "" } },
                { "PRD-5", new Product() { Id = 5, Identifier = "PRD-5", Price = 15m, SupportedIncentives = SupportedIncentiveType.TestIncentiveType, Uom = "" } }
            };
        }

        public Product GetProduct(string productIdentifier)
        {
            if (_products.TryGetValue(productIdentifier, out var product))
            {
                return product;
            }
            return null;
        }
    }
}
