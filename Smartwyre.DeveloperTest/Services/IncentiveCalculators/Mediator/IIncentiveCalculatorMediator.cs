using Smartwyre.DeveloperTest.Services.IncentiveCalculators.Interfaces;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services.IncentiveCalculators.Mediator
{
    public interface IIncentiveCalculatorMediator
    {
        /// <summary>
        /// Returns the required class to make the rebate calculation
        /// </summary>
        /// <param name="incentiveType">Rebate incentive type</param>
        /// <returns></returns>
        IIncentiveCalculator GetCalculator(IncentiveType incentiveType);
    }
}
