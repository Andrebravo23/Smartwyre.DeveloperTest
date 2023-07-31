using FluentAssertions;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Tests.FakeClasses;
using Smartwyre.DeveloperTest.Types;
using System;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests;

public class PaymentServiceTests
{
    private readonly IRebateService _rebateService;

    public PaymentServiceTests()
    {
        _rebateService = new RebateService(
            new FakeRebateDataStore(),
            new FakeProductDataStore(),
            new FakeRebateCalculationDataStore(),
            new FakeIncentiveCalculatorMediator()
            );
    }

    [Fact]
    public void Test_AmountPerUom_IncentiveType_Rebate()
    {
        CalculateRebateRequest request = new() { ProductIdentifier = "PRD-1", RebateIdentifier = "RBT-1", Volume = 2 };

        CalculateRebateResult expectedResult = new() { Amount = 20m, Success = true };

        CalculateRebateResult actualResult = _rebateService.Calculate(request);

        expectedResult.Should().BeEquivalentTo(actualResult);
    }

    [Fact]
    public void Test_FixedCashAmount_IncentiveType_Rebate()
    {
        CalculateRebateRequest request = new() { ProductIdentifier = "PRD-2", RebateIdentifier = "RBT-2", Volume = 2 };

        CalculateRebateResult expectedResult = new() { Amount = 100m, Success = true };

        CalculateRebateResult actualResult = _rebateService.Calculate(request);

        expectedResult.Should().BeEquivalentTo(actualResult);
    }

    [Fact]
    public void Test_FixedRateRebate_IncentiveType_Rebate()
    {
        CalculateRebateRequest request = new() { ProductIdentifier = "PRD-3", RebateIdentifier = "RBT-3", Volume = 1 };

        CalculateRebateResult expectedResult = new() { Amount = 12.5m, Success = true };

        CalculateRebateResult actualResult = _rebateService.Calculate(request);

        expectedResult.Should().BeEquivalentTo(actualResult);
    }

    [Fact]
    public void Test_ProductWithMultipleSupportedIncentiveTypes()
    {
        CalculateRebateRequest fixedCashAmountRequest = new() { ProductIdentifier = "PRD-4", RebateIdentifier = "RBT-2", Volume = 5 };
        
        CalculateRebateResult expectedFixedCashAmountResult = new() { Amount = 100m, Success = true };

        CalculateRebateResult actualFixedCashAmountResult = _rebateService.Calculate(fixedCashAmountRequest);

        expectedFixedCashAmountResult.Should().BeEquivalentTo(actualFixedCashAmountResult);

        CalculateRebateRequest fixedRebateRateRequest = new() { ProductIdentifier = "PRD-4", RebateIdentifier = "RBT-3", Volume = 1 };

        CalculateRebateResult expectedFixedRebateRateResult = new() { Amount = 62.75m, Success = true };

        CalculateRebateResult actualFixedRebateRateResult = _rebateService.Calculate(fixedRebateRateRequest);

        expectedFixedRebateRateResult.Should().BeEquivalentTo(actualFixedRebateRateResult);
    }

    [Fact]
    public void Test_IncentiveTypeNotSupportedByProduct()
    {
        CalculateRebateRequest fixedCashAmountRequest = new() { ProductIdentifier = "PRD-4", RebateIdentifier = "RBT-1", Volume = 5 };

        CalculateRebateResult expectedFixedCashAmountResult = new();

        CalculateRebateResult actualFixedCashAmountResult = _rebateService.Calculate(fixedCashAmountRequest);

        expectedFixedCashAmountResult.Should().BeEquivalentTo(actualFixedCashAmountResult);
    }

    [Fact]
    public void Test_InvalidRequest_ProductDoesNotExist()
    {
        CalculateRebateRequest request = new() { ProductIdentifier = "PRD-5000", RebateIdentifier = "RBT-1", Volume = 5 };
        
        CalculateRebateResult expectedResult = new();

        CalculateRebateResult actualResult = _rebateService.Calculate(request);

        actualResult.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public void Test_InvalidRequest_RebateDoesNotExist()
    {
        CalculateRebateRequest request = new() { ProductIdentifier = "PRD-2", RebateIdentifier = "RBT-1000", Volume = 5 };

        CalculateRebateResult expectedResult = new();

        CalculateRebateResult actualResult = _rebateService.Calculate(request);

        actualResult.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public void Test_InvalidRequest_VolumeIsEqualOrLowerThanZero()
    {
        CalculateRebateRequest request = new() { ProductIdentifier = "PRD-2", RebateIdentifier = "RBT-1", Volume = -5 };

        CalculateRebateResult expectedResult = new();

        CalculateRebateResult actualResult = _rebateService.Calculate(request);

        actualResult.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public void Test_InvalidRequest_IncentiveCalculatorDoesNotExist()
    {
        CalculateRebateRequest request = new() { ProductIdentifier = "PRD-5", RebateIdentifier = "RBT-4", Volume = -5 };
    
        try
        {
            CalculateRebateResult actualResult = _rebateService.Calculate(request);
        }
        catch (Exception ex)
        {
            ex.Should().BeOfType<NotImplementedException>();
        }
    }
}
