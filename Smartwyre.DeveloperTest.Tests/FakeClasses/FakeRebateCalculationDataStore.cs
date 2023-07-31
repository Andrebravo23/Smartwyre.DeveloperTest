using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;

namespace Smartwyre.DeveloperTest.Tests.FakeClasses
{
    public class FakeRebateCalculationDataStore : IRebateCalculationDataStore
    {
        public List<RebateCalculation> _rebateCalculations;

        public FakeRebateCalculationDataStore()
        {
            _rebateCalculations = new List<RebateCalculation>();
        }

        public void StoreCalculationResult(decimal amount, Rebate rebate)
        {
            RebateCalculation rebateCalculation = new()
            {
                Amount = amount,
                RebateIdentifier = rebate.Identifier,
                IncentiveType = rebate.Incentive,
            };

            _rebateCalculations.Add(rebateCalculation);
        }
    }
}
