using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Data.Implementation
{
    public class RebateCalculationDataStore : IRebateCalculationDataStore
    {
        public void StoreCalculationResult(decimal amount, Rebate rebate)
        {
            RebateCalculation rebateCalculation = new()
            {
                RebateIdentifier = rebate.Identifier,
                Amount = amount,
                IncentiveType = rebate.Incentive
            };
            // Code to store the rebateCalculation
        }
    }
}
