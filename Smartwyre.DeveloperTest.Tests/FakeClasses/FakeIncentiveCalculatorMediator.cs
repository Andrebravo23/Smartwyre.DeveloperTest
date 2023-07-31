using Smartwyre.DeveloperTest.Services.IncentiveCalculators.Implementation;
using Smartwyre.DeveloperTest.Services.IncentiveCalculators.Interfaces;
using Smartwyre.DeveloperTest.Services.IncentiveCalculators.Mediator;
using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;

namespace Smartwyre.DeveloperTest.Tests.FakeClasses
{
    public class FakeIncentiveCalculatorMediator : IIncentiveCalculatorMediator
    {
        private readonly Dictionary<IncentiveType, IIncentiveCalculator> _calculatorDictionary;

        public FakeIncentiveCalculatorMediator()
        {
            _calculatorDictionary = new Dictionary<IncentiveType, IIncentiveCalculator>
        {
            { IncentiveType.FixedCashAmount, new FixedCashAmountCalculator() },
            { IncentiveType.FixedRateRebate, new FixedRateRebateCalculator() },
            { IncentiveType.AmountPerUom, new AmountPerUomCalculator() }
        };
        }

        public IIncentiveCalculator GetCalculator(IncentiveType incentiveType)
        {
            if (_calculatorDictionary.TryGetValue(incentiveType, out var calculator))
            {
                return calculator;
            }

            return null;
        }
    }

}