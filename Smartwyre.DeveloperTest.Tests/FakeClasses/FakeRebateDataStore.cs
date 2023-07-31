using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;

namespace Smartwyre.DeveloperTest.Tests.FakeClasses
{
    public class FakeRebateDataStore : IRebateDataStore
    {
        private readonly Dictionary<string, Rebate> _rebates;

        public FakeRebateDataStore()
        {
            _rebates = new Dictionary<string, Rebate>
            {
                { "RBT-1", new Rebate() { Identifier = "RBT-1", Amount = 10m, Incentive = IncentiveType.AmountPerUom, Percentage = 0.2m } },
                { "RBT-2", new Rebate() { Identifier = "RBT-2", Amount = 100m, Incentive = IncentiveType.FixedCashAmount, Percentage = 0.5m } },
                { "RBT-3", new Rebate() { Identifier = "RBT-3", Amount = 35m, Incentive = IncentiveType.FixedRateRebate, Percentage = 0.5m } },
                { "RBT-4", new Rebate() { Identifier = "RBT-4", Amount = 3.5m, Incentive = IncentiveType.TestIncentiveType, Percentage = 0.1m } },
            };
        }

        public Rebate GetRebate(string rebateIdentifier)
        {
            if (_rebates.TryGetValue(rebateIdentifier, out Rebate rebate))
            {
                return rebate;
            }
            return null;
        }
    }
}
