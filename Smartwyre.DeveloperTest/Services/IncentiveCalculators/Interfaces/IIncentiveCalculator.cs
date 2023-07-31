using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services.IncentiveCalculators.Interfaces
{
    public interface IIncentiveCalculator
    {
        CalculateRebateResult Calculate(Rebate rebate, Product product, decimal volume);

        bool IsSupportedByProduct(Product product);
    }
}
