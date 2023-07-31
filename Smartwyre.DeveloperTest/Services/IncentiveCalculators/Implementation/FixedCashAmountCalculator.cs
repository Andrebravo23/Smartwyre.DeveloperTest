using Smartwyre.DeveloperTest.Attributes;
using Smartwyre.DeveloperTest.Services.IncentiveCalculators.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services.IncentiveCalculators.Implementation
{
    [IncentiveType(IncentiveType.FixedCashAmount)]
    public class FixedCashAmountCalculator : IIncentiveCalculator
    {
        public CalculateRebateResult Calculate(Rebate rebate, Product product, decimal volume)
        {
            CalculateRebateResult result = new();

            if (rebate.Amount == 0)
            {
                result.Success = false;
            }
            else
            {
                result.Amount = rebate.Amount;
                result.Success = true;
            }

            return result;
        }

        public bool IsSupportedByProduct(Product product)
        {
            return product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount);
        }
    }
}
