using System.Runtime.CompilerServices;
using Commons.Dsl;
using Dsl.Gherkin;
using Optivem.EShop.SystemTest.Core;
using Optivem.EShop.SystemTest.Core.Gherkin;
using Optivem.EShop.SystemTest.Core.Shop.Commons.Dtos.Orders;
using Optivem.EShop.SystemTest.Core.Shop.Dsl.Verifications;

namespace Dsl.Gherkin.Then;

public abstract class BaseThenAssertionOrder<TSuccessResponse, TSuccessVerification, TDerived>
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
    where TDerived : BaseThenAssertionOrder<TSuccessResponse, TSuccessVerification, TDerived>
{
    protected readonly ThenClause<TSuccessResponse, TSuccessVerification> _thenClause;
    protected readonly Func<Task<string>> _orderNumberFactory;
    protected readonly List<Action<ViewOrderVerification>> _verifications = [];

    protected BaseThenAssertionOrder(
        ThenClause<TSuccessResponse, TSuccessVerification> thenClause,
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

    public TDerived HasBasePrice(decimal expectedBasePrice)
    {
        _verifications.Add(v => v.BasePrice(expectedBasePrice));
        return Self;
    }

    public TDerived HasBasePrice(string basePrice)
    {
        _verifications.Add(v => v.BasePrice(basePrice));
        return Self;
    }

    public TDerived HasSubtotalPrice(decimal expectedSubtotalPrice)
    {
        _verifications.Add(v => v.SubtotalPrice(expectedSubtotalPrice));
        return Self;
    }

    public TDerived HasSubtotalPrice(string expectedSubtotalPrice)
    {
        _verifications.Add(v => v.SubtotalPrice(expectedSubtotalPrice));
        return Self;
    }

    public TDerived HasTotalPrice(decimal expectedTotalPrice)
    {
        _verifications.Add(v => v.TotalPrice(expectedTotalPrice));
        return Self;
    }

    public TDerived HasTotalPrice(string expectedTotalPrice)
    {
        _verifications.Add(v => v.TotalPrice(expectedTotalPrice));
        return Self;
    }

    public TDerived HasTaxRate(decimal expectedTaxRate)
    {
        _verifications.Add(v => v.TaxRate(expectedTaxRate));
        return Self;
    }

    public TDerived HasTaxRate(string expectedTaxRate)
    {
        _verifications.Add(v => v.TaxRate(expectedTaxRate));
        return Self;
    }

    public TDerived HasTaxAmount(string expectedTaxAmount)
    {
        _verifications.Add(v => v.TaxAmount(expectedTaxAmount));
        return Self;
    }

    public TDerived HasDiscountRate(decimal expectedDiscountRate)
    {
        _verifications.Add(v => v.DiscountRate(expectedDiscountRate));
        return Self;
    }

    public TDerived HasDiscountAmount(decimal expectedDiscountAmount)
    {
        _verifications.Add(v => v.DiscountAmount(expectedDiscountAmount));
        return Self;
    }

    public TDerived HasDiscountAmount(string expectedDiscountAmount)
    {
        _verifications.Add(v => v.DiscountAmount(expectedDiscountAmount));
        return Self;
    }

    public TDerived HasAppliedCoupon(string expectedCouponCode)
    {
        _verifications.Add(v => v.AppliedCouponCode(expectedCouponCode));
        return Self;
    }

    public TDerived HasAppliedCoupon()
    {
        _verifications.Add(v => v.AppliedCouponCode(GherkinDefaults.DefaultCouponCode));
        return Self;
    }

    public TDerived HasOrderNumberPrefix(string expectedPrefix)
    {
        _verifications.Add(v => v.OrderNumberHasPrefix(expectedPrefix));
        return Self;
    }

    public TDerived HasSku(string expectedSku)
    {
        _verifications.Add(v => v.Sku(expectedSku));
        return Self;
    }

    public TDerived HasQuantity(int expectedQuantity)
    {
        _verifications.Add(v => v.Quantity(expectedQuantity));
        return Self;
    }

    public TDerived HasCountry(string expectedCountry)
    {
        _verifications.Add(v => v.Country(expectedCountry));
        return Self;
    }

    public TDerived HasUnitPrice(decimal expectedUnitPrice)
    {
        _verifications.Add(v => v.UnitPrice(expectedUnitPrice));
        return Self;
    }

    public TDerived HasDiscountRateGreaterThanOrEqualToZero()
    {
        _verifications.Add(v => v.DiscountRateGreaterThanOrEqualToZero());
        return Self;
    }

    public TDerived HasDiscountAmountGreaterThanOrEqualToZero()
    {
        _verifications.Add(v => v.DiscountAmountGreaterThanOrEqualToZero());
        return Self;
    }

    public TDerived HasSubtotalPriceGreaterThanZero()
    {
        _verifications.Add(v => v.SubtotalPriceGreaterThanZero());
        return Self;
    }

    public TDerived HasTaxRateGreaterThanOrEqualToZero()
    {
        _verifications.Add(v => v.TaxRateGreaterThanOrEqualToZero());
        return Self;
    }

    public TDerived HasTaxAmountGreaterThanOrEqualToZero()
    {
        _verifications.Add(v => v.TaxAmountGreaterThanOrEqualToZero());
        return Self;
    }

    public TDerived HasTotalPriceGreaterThanZero()
    {
        _verifications.Add(v => v.TotalPriceGreaterThanZero());
        return Self;
    }

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
