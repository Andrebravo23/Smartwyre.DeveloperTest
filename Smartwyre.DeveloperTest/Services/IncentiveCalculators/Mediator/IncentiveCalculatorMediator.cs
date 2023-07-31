using Microsoft.Extensions.DependencyInjection;
using Smartwyre.DeveloperTest.Attributes;
using Smartwyre.DeveloperTest.Services.IncentiveCalculators.Interfaces;
using Smartwyre.DeveloperTest.Types;
using System;
using System.Linq;
using System.Reflection;

namespace Smartwyre.DeveloperTest.Services.IncentiveCalculators.Mediator
{
    public class IncentiveCalculatorMediator : IIncentiveCalculatorMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public IncentiveCalculatorMediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IIncentiveCalculator GetCalculator(IncentiveType incentiveType)
        {
            var calculators = typeof(IIncentiveCalculator).Assembly.GetTypes()
                .Where(t => t.GetCustomAttributes<IncentiveTypeAttribute>().Any(a => a.IncentiveType == incentiveType));

            if (!calculators.Any()) throw new NotImplementedException($"Could not find an Incentive Calculator for Incentive Type {incentiveType}.");

            var calculatorType = calculators.First();
            return _serviceProvider.GetRequiredService(calculatorType) as IIncentiveCalculator;
        }
    }

}
