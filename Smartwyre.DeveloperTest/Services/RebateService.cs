using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Services.IncentiveCalculators.Interfaces;
using Smartwyre.DeveloperTest.Services.IncentiveCalculators.Mediator;
using Smartwyre.DeveloperTest.Types;
using System;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{
    private readonly IRebateDataStore _rebateDataStore;
    private readonly IProductDataStore _productDataStore;
    private readonly IRebateCalculationDataStore _rebateCalculationDataStore;
    private readonly IIncentiveCalculatorMediator _incentiveCalculatorMediator;

    public RebateService(IRebateDataStore rebateDataStore, IProductDataStore productDataStore, IRebateCalculationDataStore rebateCalculationDataStore, IIncentiveCalculatorMediator incentiveCalculatorMediator)
    {
        _rebateDataStore = rebateDataStore;
        _productDataStore = productDataStore;
        _rebateCalculationDataStore = rebateCalculationDataStore;
        _incentiveCalculatorMediator = incentiveCalculatorMediator;
    }

    public CalculateRebateResult Calculate(CalculateRebateRequest request)
    {
        Rebate rebate = _rebateDataStore.GetRebate(request.RebateIdentifier);
        Product product = _productDataStore.GetProduct(request.ProductIdentifier);

        if (rebate == null || product == null)
        {
            // The result can be extended to retrieve more information on error cases
            return new CalculateRebateResult();
        }

        // The mediator will try to find the required calculator, if it can't find it, it will throw an exception
        IIncentiveCalculator incentiveCalculator = _incentiveCalculatorMediator.GetCalculator(rebate.Incentive);
        
        if (!incentiveCalculator.IsSupportedByProduct(product))
        {
            // Here an error can be returned specifying that the product doesn't support this incentive type
            return new CalculateRebateResult();
        }
     
        var result = incentiveCalculator.Calculate(rebate, product, request.Volume);

        _rebateCalculationDataStore.StoreCalculationResult(result.Amount, rebate);

        return result;
    }
}
