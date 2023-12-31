﻿using Microsoft.Extensions.DependencyInjection;
using Smartwyre.DeveloperTest.Data.Implementation;
using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Services.IncentiveCalculators.Implementation;
using Smartwyre.DeveloperTest.Services.IncentiveCalculators.Mediator;
using Smartwyre.DeveloperTest.Services;
using System;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{
    static void Main(string[] args)
    { 
        var serviceCollection = new ServiceCollection();

        ConfigureServices(serviceCollection);

        using var serviceProvider = serviceCollection.BuildServiceProvider();
        
        var rebateService = serviceProvider.GetRequiredService<IRebateService>();

        // here rebateService can be used to make the calculations. Run the tests to check that the implementation is correct.
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IProductDataStore, ProductDataStore>();
        services.AddScoped<IRebateDataStore, RebateDataStore>();
        services.AddScoped<IRebateCalculationDataStore, RebateCalculationDataStore>();

        services.AddScoped<FixedCashAmountCalculator>();
        services.AddScoped<FixedRateRebateCalculator>();
        services.AddScoped<AmountPerUomCalculator>();

        services.AddScoped<IIncentiveCalculatorMediator, IncentiveCalculatorMediator>();

        services.AddScoped<IRebateService, RebateService>();
    }
}
