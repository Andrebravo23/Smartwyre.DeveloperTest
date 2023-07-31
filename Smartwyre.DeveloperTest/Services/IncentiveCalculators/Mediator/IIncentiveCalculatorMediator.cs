using Smartwyre.DeveloperTest.Services.IncentiveCalculators.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services.IncentiveCalculators.Mediator
{
    public interface IIncentiveCalculatorMediator
    {
        IIncentiveCalculator GetCalculator(IncentiveType incentiveType);
    }
}
