using System.Runtime.CompilerServices;
using Commons.Dsl;
using Optivem.EShop.SystemTest.Core.Gherkin.Then;
using Optivem.EShop.SystemTest.Core.Shop.Commons.Dtos.Orders;

namespace Dsl.Gherkin.Then;

public class ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification>
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    private readonly ThenClause<TSuccessResponse, TSuccessVerification> _thenClause;
    private readonly Func<Task<ThenOrderBuilder<TSuccessResponse, TSuccessVerification>>> _builderFactory;
    private readonly List<Func<ThenOrderBuilder<TSuccessResponse, TSuccessVerification>, Task>> _verifications = [];

    internal ThenSuccessAssertionOrder(
        ThenClause<TSuccessResponse, TSuccessVerification> thenClause,
        Func<Task<ThenOrderBuilder<TSuccessResponse, TSuccessVerification>>> builderFactory)
    {
        _thenClause = thenClause;
        _builderFactory = builderFactory;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasStatus(OrderStatus expectedStatus)
    {
        _verifications.Add(b => b.HasStatus(expectedStatus));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasBasePrice(decimal expectedBasePrice)
    {
        _verifications.Add(b => b.HasBasePrice(expectedBasePrice));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasBasePrice(string basePrice)
    {
        _verifications.Add(b => b.HasBasePrice(basePrice));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasSubtotalPrice(decimal expectedSubtotalPrice)
    {
        _verifications.Add(b => b.HasSubtotalPrice(expectedSubtotalPrice));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasSubtotalPrice(string expectedSubtotalPrice)
    {
        _verifications.Add(b => b.HasSubtotalPrice(expectedSubtotalPrice));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasTotalPrice(decimal expectedTotalPrice)
    {
        _verifications.Add(b => b.HasTotalPrice(expectedTotalPrice));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasTotalPrice(string expectedTotalPrice)
    {
        _verifications.Add(b => b.HasTotalPrice(expectedTotalPrice));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasTaxRate(decimal expectedTaxRate)
    {
        _verifications.Add(b => b.HasTaxRate(expectedTaxRate));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasTaxRate(string expectedTaxRate)
    {
        _verifications.Add(b => b.HasTaxRate(expectedTaxRate));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasTaxAmount(string expectedTaxAmount)
    {
        _verifications.Add(b => b.HasTaxAmount(expectedTaxAmount));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasDiscountRate(decimal expectedDiscountRate)
    {
        _verifications.Add(b => b.HasDiscountRate(expectedDiscountRate));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasDiscountAmount(decimal expectedDiscountAmount)
    {
        _verifications.Add(b => b.HasDiscountAmount(expectedDiscountAmount));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasDiscountAmount(string expectedDiscountAmount)
    {
        _verifications.Add(b => b.HasDiscountAmount(expectedDiscountAmount));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasAppliedCoupon(string expectedCouponCode)
    {
        _verifications.Add(b => b.HasAppliedCoupon(expectedCouponCode));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasAppliedCoupon()
    {
        _verifications.Add(b => b.HasAppliedCoupon());
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasOrderNumberPrefix(string expectedPrefix)
    {
        _verifications.Add(b => b.HasOrderNumberPrefix(expectedPrefix));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasSku(string expectedSku)
    {
        _verifications.Add(b => b.HasSku(expectedSku));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasQuantity(int expectedQuantity)
    {
        _verifications.Add(b => b.HasQuantity(expectedQuantity));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasCountry(string expectedCountry)
    {
        _verifications.Add(b => b.HasCountry(expectedCountry));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasUnitPrice(decimal expectedUnitPrice)
    {
        _verifications.Add(b => b.HasUnitPrice(expectedUnitPrice));
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasDiscountRateGreaterThanOrEqualToZero()
    {
        _verifications.Add(b => b.HasDiscountRateGreaterThanOrEqualToZero());
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasDiscountAmountGreaterThanOrEqualToZero()
    {
        _verifications.Add(b => b.HasDiscountAmountGreaterThanOrEqualToZero());
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasSubtotalPriceGreaterThanZero()
    {
        _verifications.Add(b => b.HasSubtotalPriceGreaterThanZero());
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasTaxRateGreaterThanOrEqualToZero()
    {
        _verifications.Add(b => b.HasTaxRateGreaterThanOrEqualToZero());
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasTaxAmountGreaterThanOrEqualToZero()
    {
        _verifications.Add(b => b.HasTaxAmountGreaterThanOrEqualToZero());
        return this;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> HasTotalPriceGreaterThanZero()
    {
        _verifications.Add(b => b.HasTotalPriceGreaterThanZero());
        return this;
    }

    public TaskAwaiter GetAwaiter() => Execute().GetAwaiter();

    private async Task Execute()
    {
        var result = await _thenClause.GetExecutionResult();
        _ = result.Result.ShouldSucceed();

        var builder = await _builderFactory();
        foreach (var verification in _verifications)
        {
            await verification(builder);
        }
    }
}
