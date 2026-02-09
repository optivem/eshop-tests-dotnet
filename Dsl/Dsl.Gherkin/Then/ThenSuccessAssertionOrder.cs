using System.Runtime.CompilerServices;
using Commons.Dsl;
using Optivem.EShop.SystemTest.Core;
using Optivem.EShop.SystemTest.Core.Gherkin;
using Optivem.EShop.SystemTest.Core.Shop.Commons.Dtos.Orders;
using Optivem.EShop.SystemTest.Core.Shop.Dsl.Verifications;
namespace Dsl.Gherkin.Then;

public class ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification>
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    private readonly ThenClause<TSuccessResponse, TSuccessVerification> _thenClause;
    private readonly Func<Task<string>> _orderNumberFactory;
    private readonly List<Action<ViewOrderVerification>> _verifications = [];

    internal ThenSuccessAssertionOrder(
        ThenClause<TSuccessResponse, TSuccessVerification> thenClause,
        Func<Task<string>> orderNumberFactory)
    {
        _thenClause = thenClause;
        _orderNumberFactory = orderNumberFactory;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasStatus(OrderStatus expectedStatus)
    {
        _verifications.Add(v => v.Status(expectedStatus));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasBasePrice(decimal expectedBasePrice)
    {
        _verifications.Add(v => v.BasePrice(expectedBasePrice));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasBasePrice(string basePrice)
    {
        _verifications.Add(v => v.BasePrice(basePrice));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasSubtotalPrice(decimal expectedSubtotalPrice)
    {
        _verifications.Add(v => v.SubtotalPrice(expectedSubtotalPrice));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasSubtotalPrice(string expectedSubtotalPrice)
    {
        _verifications.Add(v => v.SubtotalPrice(expectedSubtotalPrice));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasTotalPrice(decimal expectedTotalPrice)
    {
        _verifications.Add(v => v.TotalPrice(expectedTotalPrice));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasTotalPrice(string expectedTotalPrice)
    {
        _verifications.Add(v => v.TotalPrice(expectedTotalPrice));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasTaxRate(decimal expectedTaxRate)
    {
        _verifications.Add(v => v.TaxRate(expectedTaxRate));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasTaxRate(string expectedTaxRate)
    {
        _verifications.Add(v => v.TaxRate(expectedTaxRate));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasTaxAmount(string expectedTaxAmount)
    {
        _verifications.Add(v => v.TaxAmount(expectedTaxAmount));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasDiscountRate(decimal expectedDiscountRate)
    {
        _verifications.Add(v => v.DiscountRate(expectedDiscountRate));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasDiscountAmount(decimal expectedDiscountAmount)
    {
        _verifications.Add(v => v.DiscountAmount(expectedDiscountAmount));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasDiscountAmount(string expectedDiscountAmount)
    {
        _verifications.Add(v => v.DiscountAmount(expectedDiscountAmount));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasAppliedCoupon(string expectedCouponCode)
    {
        _verifications.Add(v => v.AppliedCouponCode(expectedCouponCode));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasAppliedCoupon()
    {
        _verifications.Add(v => v.AppliedCouponCode(GherkinDefaults.DefaultCouponCode));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasOrderNumberPrefix(string expectedPrefix)
    {
        _verifications.Add(v => v.OrderNumberHasPrefix(expectedPrefix));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasSku(string expectedSku)
    {
        _verifications.Add(v => v.Sku(expectedSku));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasQuantity(int expectedQuantity)
    {
        _verifications.Add(v => v.Quantity(expectedQuantity));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasCountry(string expectedCountry)
    {
        _verifications.Add(v => v.Country(expectedCountry));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasUnitPrice(decimal expectedUnitPrice)
    {
        _verifications.Add(v => v.UnitPrice(expectedUnitPrice));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasDiscountRateGreaterThanOrEqualToZero()
    {
        _verifications.Add(v => v.DiscountRateGreaterThanOrEqualToZero());
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasDiscountAmountGreaterThanOrEqualToZero()
    {
        _verifications.Add(v => v.DiscountAmountGreaterThanOrEqualToZero());
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasSubtotalPriceGreaterThanZero()
    {
        _verifications.Add(v => v.SubtotalPriceGreaterThanZero());
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasTaxRateGreaterThanOrEqualToZero()
    {
        _verifications.Add(v => v.TaxRateGreaterThanOrEqualToZero());
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasTaxAmountGreaterThanOrEqualToZero()
    {
        _verifications.Add(v => v.TaxAmountGreaterThanOrEqualToZero());
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasTotalPriceGreaterThanZero()
    {
        _verifications.Add(v => v.TotalPriceGreaterThanZero());
        return this;
    }

    public TaskAwaiter GetAwaiter() => Execute().GetAwaiter();

    private async Task Execute()
    {
        var result = await _thenClause.GetExecutionResult();
        _ = result.Result.ShouldSucceed();

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
