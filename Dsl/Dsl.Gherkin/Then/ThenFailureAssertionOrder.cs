using System.Runtime.CompilerServices;
using Commons.Dsl;
using Optivem.EShop.SystemTest.Core.Shop.Commons.Dtos.Orders;

namespace Dsl.Gherkin.Then;

/// <summary>
/// Order verification in failure path - no success check, runs failure assertions first then order verifications.
/// </summary>
public class ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification>
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    private readonly ThenClause<TSuccessResponse, TSuccessVerification> _thenClause;
    private readonly List<Action<ThenFailureBuilder<TSuccessResponse, TSuccessVerification>>> _failureAssertions;
    private readonly Func<Task<ThenOrderBuilder<TSuccessResponse, TSuccessVerification>>> _builderFactory;
    private readonly List<Func<ThenOrderBuilder<TSuccessResponse, TSuccessVerification>, Task>> _verifications = [];

    internal ThenFailureAssertionOrder(
        ThenClause<TSuccessResponse, TSuccessVerification> thenClause,
        List<Action<ThenFailureBuilder<TSuccessResponse, TSuccessVerification>>> failureAssertions,
        Func<Task<ThenOrderBuilder<TSuccessResponse, TSuccessVerification>>> builderFactory)
    {
        _thenClause = thenClause;
        _failureAssertions = failureAssertions;
        _builderFactory = builderFactory;
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> HasStatus(OrderStatus expectedStatus)
    {
        _verifications.Add(b => b.HasStatus(expectedStatus));
        return this;
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> HasBasePrice(decimal expectedBasePrice)
    {
        _verifications.Add(b => b.HasBasePrice(expectedBasePrice));
        return this;
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> HasBasePrice(string basePrice)
    {
        _verifications.Add(b => b.HasBasePrice(basePrice));
        return this;
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> HasSubtotalPrice(decimal expectedSubtotalPrice)
    {
        _verifications.Add(b => b.HasSubtotalPrice(expectedSubtotalPrice));
        return this;
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> HasSubtotalPrice(string expectedSubtotalPrice)
    {
        _verifications.Add(b => b.HasSubtotalPrice(expectedSubtotalPrice));
        return this;
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> HasTotalPrice(decimal expectedTotalPrice)
    {
        _verifications.Add(b => b.HasTotalPrice(expectedTotalPrice));
        return this;
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> HasTotalPrice(string expectedTotalPrice)
    {
        _verifications.Add(b => b.HasTotalPrice(expectedTotalPrice));
        return this;
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> HasTaxRate(decimal expectedTaxRate)
    {
        _verifications.Add(b => b.HasTaxRate(expectedTaxRate));
        return this;
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> HasTaxRate(string expectedTaxRate)
    {
        _verifications.Add(b => b.HasTaxRate(expectedTaxRate));
        return this;
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> HasTaxAmount(string expectedTaxAmount)
    {
        _verifications.Add(b => b.HasTaxAmount(expectedTaxAmount));
        return this;
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> HasDiscountRate(decimal expectedDiscountRate)
    {
        _verifications.Add(b => b.HasDiscountRate(expectedDiscountRate));
        return this;
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> HasDiscountAmount(decimal expectedDiscountAmount)
    {
        _verifications.Add(b => b.HasDiscountAmount(expectedDiscountAmount));
        return this;
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> HasDiscountAmount(string expectedDiscountAmount)
    {
        _verifications.Add(b => b.HasDiscountAmount(expectedDiscountAmount));
        return this;
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> HasAppliedCoupon(string expectedCouponCode)
    {
        _verifications.Add(b => b.HasAppliedCoupon(expectedCouponCode));
        return this;
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> HasAppliedCoupon()
    {
        _verifications.Add(b => b.HasAppliedCoupon());
        return this;
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> HasOrderNumberPrefix(string expectedPrefix)
    {
        _verifications.Add(b => b.HasOrderNumberPrefix(expectedPrefix));
        return this;
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> HasSku(string expectedSku)
    {
        _verifications.Add(b => b.HasSku(expectedSku));
        return this;
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> HasQuantity(int expectedQuantity)
    {
        _verifications.Add(b => b.HasQuantity(expectedQuantity));
        return this;
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> HasCountry(string expectedCountry)
    {
        _verifications.Add(b => b.HasCountry(expectedCountry));
        return this;
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> HasUnitPrice(decimal expectedUnitPrice)
    {
        _verifications.Add(b => b.HasUnitPrice(expectedUnitPrice));
        return this;
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> HasDiscountRateGreaterThanOrEqualToZero()
    {
        _verifications.Add(b => b.HasDiscountRateGreaterThanOrEqualToZero());
        return this;
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> HasDiscountAmountGreaterThanOrEqualToZero()
    {
        _verifications.Add(b => b.HasDiscountAmountGreaterThanOrEqualToZero());
        return this;
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> HasSubtotalPriceGreaterThanZero()
    {
        _verifications.Add(b => b.HasSubtotalPriceGreaterThanZero());
        return this;
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> HasTaxRateGreaterThanOrEqualToZero()
    {
        _verifications.Add(b => b.HasTaxRateGreaterThanOrEqualToZero());
        return this;
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> HasTaxAmountGreaterThanOrEqualToZero()
    {
        _verifications.Add(b => b.HasTaxAmountGreaterThanOrEqualToZero());
        return this;
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> HasTotalPriceGreaterThanZero()
    {
        _verifications.Add(b => b.HasTotalPriceGreaterThanZero());
        return this;
    }

    public TaskAwaiter GetAwaiter() => Execute().GetAwaiter();

    private async Task Execute()
    {
        var result = await _thenClause.GetExecutionResult();
        var failureBuilder = new ThenFailureBuilder<TSuccessResponse, TSuccessVerification>(_thenClause, result.Result);
        foreach (var assertion in _failureAssertions)
        {
            assertion(failureBuilder);
        }

        var orderBuilder = await _builderFactory();
        foreach (var verification in _verifications)
        {
            await verification(orderBuilder);
        }
    }
}
