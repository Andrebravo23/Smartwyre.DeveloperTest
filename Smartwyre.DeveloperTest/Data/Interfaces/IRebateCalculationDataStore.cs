using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Data.Interfaces
{
    public interface IRebateCalculationDataStore
    {
        void StoreCalculationResult(decimal amount, Rebate rebate);
    }
}
