using Smartwyre.DeveloperTest.Attributes;
using Smartwyre.DeveloperTest.Services.IncentiveCalculators.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services.IncentiveCalculators.Implementation
{
    [IncentiveType(IncentiveType.FixedRateRebate)]
    public class FixedRateRebateCalculator : IIncentiveCalculator
    {
        public CalculateRebateResult Calculate(Rebate rebate, Product product, decimal volume)
        {
            CalculateRebateResult result = new();

            if (rebate.Percentage == 0 || product.Price == 0 || volume <= 0)
            {
                result.Success = false;
            }
            else
            {
                result.Amount += product.Price * rebate.Percentage * volume;
                result.Success = true;
            }

            return result;
        }

        public bool IsSupportedByProduct(Product product)
        {
            return product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedRateRebate);
        }
    }
}
