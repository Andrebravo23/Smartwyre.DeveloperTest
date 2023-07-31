using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Data.Implementation;

public class RebateDataStore : IRebateDataStore
{
    public Rebate GetRebate(string rebateIdentifier)
    {
        // Access database to retrieve account, code removed for brevity 
        return new Rebate();
    }
}
