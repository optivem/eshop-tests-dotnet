using System.Runtime.CompilerServices;
using Commons.Dsl;
using Optivem.EShop.SystemTest.Core.Gherkin.Then;

namespace Dsl.Gherkin.Then;

public class ThenSuccessAssertionCoupon<TSuccessResponse, TSuccessVerification>
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    private readonly ThenClause<TSuccessResponse, TSuccessVerification> _thenClause;
    private readonly ThenCouponBuilder<TSuccessResponse, TSuccessVerification> _builder;
    private readonly List<Func<ThenCouponBuilder<TSuccessResponse, TSuccessVerification>, Task>> _verifications = [];

    internal ThenSuccessAssertionCoupon(
        ThenClause<TSuccessResponse, TSuccessVerification> thenClause,
        ThenCouponBuilder<TSuccessResponse, TSuccessVerification> builder)
    {
        _thenClause = thenClause;
        _builder = builder;
    }

    public ThenSuccessAssertionCoupon<TSuccessResponse, TSuccessVerification> HasDiscountRate(decimal discountRate)
    {
        _verifications.Add(b => b.HasDiscountRate(discountRate));
        return this;
    }

    public ThenSuccessAssertionCoupon<TSuccessResponse, TSuccessVerification> IsValidFrom(string validFrom)
    {
        _verifications.Add(b => b.IsValidFrom(validFrom));
        return this;
    }

    public ThenSuccessAssertionCoupon<TSuccessResponse, TSuccessVerification> IsValidTo(string validTo)
    {
        _verifications.Add(b => b.IsValidTo(validTo));
        return this;
    }

    public ThenSuccessAssertionCoupon<TSuccessResponse, TSuccessVerification> HasUsageLimit(int usageLimit)
    {
        _verifications.Add(b => b.HasUsageLimit(usageLimit));
        return this;
    }

    public ThenSuccessAssertionCoupon<TSuccessResponse, TSuccessVerification> HasUsedCount(int expectedUsedCount)
    {
        _verifications.Add(b => b.HasUsedCount(expectedUsedCount));
        return this;
    }

    public TaskAwaiter GetAwaiter() => Execute().GetAwaiter();

    private async Task Execute()
    {
        var result = await _thenClause.GetExecutionResult();
        _ = result.Result.ShouldSucceed();

        foreach (var verification in _verifications)
        {
            await verification(_builder);
        }
    }
}
