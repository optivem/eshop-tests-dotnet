using System.Runtime.CompilerServices;
using Dsl.Api.Then.Steps;
using Driver.Shared.Dsl;
using DslImpl.Gherkin;
using Optivem.EShop.SystemTest.Core;
using Optivem.EShop.SystemTest.Core.Gherkin;
using Optivem.EShop.SystemTest.Driver.Api.Shop.Dtos;
using Optivem.EShop.SystemTest.Core.Shop.Dsl.UseCases;

namespace DslImpl.Gherkin.Then;

public abstract class BaseThenResultOrder<TSuccessResponse, TSuccessVerification, TDerived>
    : IThenOrderAssertion
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
    where TDerived : BaseThenResultOrder<TSuccessResponse, TSuccessVerification, TDerived>
{
    protected readonly ThenStage<TSuccessResponse, TSuccessVerification> _thenClause;
    protected readonly Func<Task<string>> _orderNumberFactory;
    protected readonly List<Action<ViewOrderVerification>> _verifications = [];

    protected BaseThenResultOrder(
        ThenStage<TSuccessResponse, TSuccessVerification> thenClause,
        Func<Task<string>> orderNumberFactory)
    {
        _thenClause = thenClause;
        _orderNumberFactory = orderNumberFactory;
    }

    protected abstract Task RunPrelude(ExecutionResult<TSuccessResponse, TSuccessVerification> result);

    protected TDerived Self => (TDerived)this;

    public TDerived HasStatus(OrderStatus expectedStatus)
    {
        _verifications.Add(v => v.Status(expectedStatus));
        return Self;
    }

    IThenOrderAssertion IThenOrderAssertion.HasStatus(OrderStatus expectedStatus) => HasStatus(expectedStatus);

    public TDerived HasBasePrice(decimal expectedBasePrice)
    {
        _verifications.Add(v => v.BasePrice(expectedBasePrice));
        return Self;
    }

    IThenOrderAssertion IThenOrderAssertion.HasBasePrice(decimal expectedBasePrice) => HasBasePrice(expectedBasePrice);

    public TDerived HasBasePrice(string basePrice)
    {
        _verifications.Add(v => v.BasePrice(basePrice));
        return Self;
    }

    IThenOrderAssertion IThenOrderAssertion.HasBasePrice(string basePrice) => HasBasePrice(basePrice);

    public TDerived HasSubtotalPrice(decimal expectedSubtotalPrice)
    {
        _verifications.Add(v => v.SubtotalPrice(expectedSubtotalPrice));
        return Self;
    }

    IThenOrderAssertion IThenOrderAssertion.HasSubtotalPrice(decimal expectedSubtotalPrice) => HasSubtotalPrice(expectedSubtotalPrice);

    public TDerived HasSubtotalPrice(string expectedSubtotalPrice)
    {
        _verifications.Add(v => v.SubtotalPrice(expectedSubtotalPrice));
        return Self;
    }

    IThenOrderAssertion IThenOrderAssertion.HasSubtotalPrice(string expectedSubtotalPrice) => HasSubtotalPrice(expectedSubtotalPrice);

    public TDerived HasTotalPrice(decimal expectedTotalPrice)
    {
        _verifications.Add(v => v.TotalPrice(expectedTotalPrice));
        return Self;
    }

    IThenOrderAssertion IThenOrderAssertion.HasTotalPrice(decimal expectedTotalPrice) => HasTotalPrice(expectedTotalPrice);

    public TDerived HasTotalPrice(string expectedTotalPrice)
    {
        _verifications.Add(v => v.TotalPrice(expectedTotalPrice));
        return Self;
    }

    IThenOrderAssertion IThenOrderAssertion.HasTotalPrice(string expectedTotalPrice) => HasTotalPrice(expectedTotalPrice);

    public TDerived HasTaxRate(decimal expectedTaxRate)
    {
        _verifications.Add(v => v.TaxRate(expectedTaxRate));
        return Self;
    }

    IThenOrderAssertion IThenOrderAssertion.HasTaxRate(decimal expectedTaxRate) => HasTaxRate(expectedTaxRate);

    public TDerived HasTaxRate(string expectedTaxRate)
    {
        _verifications.Add(v => v.TaxRate(expectedTaxRate));
        return Self;
    }

    IThenOrderAssertion IThenOrderAssertion.HasTaxRate(string expectedTaxRate) => HasTaxRate(expectedTaxRate);

    public TDerived HasTaxAmount(string expectedTaxAmount)
    {
        _verifications.Add(v => v.TaxAmount(expectedTaxAmount));
        return Self;
    }

    IThenOrderAssertion IThenOrderAssertion.HasTaxAmount(string expectedTaxAmount) => HasTaxAmount(expectedTaxAmount);

    public TDerived HasDiscountRate(decimal expectedDiscountRate)
    {
        _verifications.Add(v => v.DiscountRate(expectedDiscountRate));
        return Self;
    }

    IThenOrderAssertion IThenOrderAssertion.HasDiscountRate(decimal expectedDiscountRate) => HasDiscountRate(expectedDiscountRate);

    public TDerived HasDiscountAmount(decimal expectedDiscountAmount)
    {
        _verifications.Add(v => v.DiscountAmount(expectedDiscountAmount));
        return Self;
    }

    IThenOrderAssertion IThenOrderAssertion.HasDiscountAmount(decimal expectedDiscountAmount) => HasDiscountAmount(expectedDiscountAmount);

    public TDerived HasDiscountAmount(string expectedDiscountAmount)
    {
        _verifications.Add(v => v.DiscountAmount(expectedDiscountAmount));
        return Self;
    }

    IThenOrderAssertion IThenOrderAssertion.HasDiscountAmount(string expectedDiscountAmount) => HasDiscountAmount(expectedDiscountAmount);

    public TDerived HasAppliedCoupon(string expectedCouponCode)
    {
        _verifications.Add(v => v.AppliedCouponCode(expectedCouponCode));
        return Self;
    }

    IThenOrderAssertion IThenOrderAssertion.HasAppliedCoupon(string expectedCouponCode) => HasAppliedCoupon(expectedCouponCode);

    public TDerived HasAppliedCoupon()
    {
        _verifications.Add(v => v.AppliedCouponCode(GherkinDefaults.DefaultCouponCode));
        return Self;
    }

    IThenOrderAssertion IThenOrderAssertion.HasAppliedCoupon() => HasAppliedCoupon();

    public TDerived HasOrderNumberPrefix(string expectedPrefix)
    {
        _verifications.Add(v => v.OrderNumberHasPrefix(expectedPrefix));
        return Self;
    }

    IThenOrderAssertion IThenOrderAssertion.HasOrderNumberPrefix(string expectedPrefix) => HasOrderNumberPrefix(expectedPrefix);

    public TDerived HasSku(string expectedSku)
    {
        _verifications.Add(v => v.Sku(expectedSku));
        return Self;
    }

    IThenOrderAssertion IThenOrderAssertion.HasSku(string expectedSku) => HasSku(expectedSku);

    public TDerived HasQuantity(int expectedQuantity)
    {
        _verifications.Add(v => v.Quantity(expectedQuantity));
        return Self;
    }

    IThenOrderAssertion IThenOrderAssertion.HasQuantity(int expectedQuantity) => HasQuantity(expectedQuantity);

    public TDerived HasCountry(string expectedCountry)
    {
        _verifications.Add(v => v.Country(expectedCountry));
        return Self;
    }

    IThenOrderAssertion IThenOrderAssertion.HasCountry(string expectedCountry) => HasCountry(expectedCountry);

    public TDerived HasUnitPrice(decimal expectedUnitPrice)
    {
        _verifications.Add(v => v.UnitPrice(expectedUnitPrice));
        return Self;
    }

    IThenOrderAssertion IThenOrderAssertion.HasUnitPrice(decimal expectedUnitPrice) => HasUnitPrice(expectedUnitPrice);

    public TDerived HasDiscountRateGreaterThanOrEqualToZero()
    {
        _verifications.Add(v => v.DiscountRateGreaterThanOrEqualToZero());
        return Self;
    }

    IThenOrderAssertion IThenOrderAssertion.HasDiscountRateGreaterThanOrEqualToZero() => HasDiscountRateGreaterThanOrEqualToZero();

    public TDerived HasDiscountAmountGreaterThanOrEqualToZero()
    {
        _verifications.Add(v => v.DiscountAmountGreaterThanOrEqualToZero());
        return Self;
    }

    IThenOrderAssertion IThenOrderAssertion.HasDiscountAmountGreaterThanOrEqualToZero() => HasDiscountAmountGreaterThanOrEqualToZero();

    public TDerived HasSubtotalPriceGreaterThanZero()
    {
        _verifications.Add(v => v.SubtotalPriceGreaterThanZero());
        return Self;
    }

    IThenOrderAssertion IThenOrderAssertion.HasSubtotalPriceGreaterThanZero() => HasSubtotalPriceGreaterThanZero();

    public TDerived HasTaxRateGreaterThanOrEqualToZero()
    {
        _verifications.Add(v => v.TaxRateGreaterThanOrEqualToZero());
        return Self;
    }

    IThenOrderAssertion IThenOrderAssertion.HasTaxRateGreaterThanOrEqualToZero() => HasTaxRateGreaterThanOrEqualToZero();

    public TDerived HasTaxAmountGreaterThanOrEqualToZero()
    {
        _verifications.Add(v => v.TaxAmountGreaterThanOrEqualToZero());
        return Self;
    }

    IThenOrderAssertion IThenOrderAssertion.HasTaxAmountGreaterThanOrEqualToZero() => HasTaxAmountGreaterThanOrEqualToZero();

    public TDerived HasTotalPriceGreaterThanZero()
    {
        _verifications.Add(v => v.TotalPriceGreaterThanZero());
        return Self;
    }

    IThenOrderAssertion IThenOrderAssertion.HasTotalPriceGreaterThanZero() => HasTotalPriceGreaterThanZero();

    public TaskAwaiter GetAwaiter() => Execute().GetAwaiter();

    private async Task Execute()
    {
        var result = await _thenClause.GetExecutionResult();
        await RunPrelude(result);

        var orderNumber = await _orderNumberFactory();
        var shop = await _thenClause.App.Shop(_thenClause.Channel);
        var viewOrderResult = await shop.ViewOrder().OrderNumber(orderNumber).Execute();
        var verification = viewOrderResult.ShouldSucceed();

        foreach (var v in _verifications)
        {
            v(verification);
        }
    }
}
