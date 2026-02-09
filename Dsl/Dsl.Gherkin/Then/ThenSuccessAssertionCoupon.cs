using System.Runtime.CompilerServices;
using Commons.Dsl;
using Optivem.EShop.SystemTest.Core;
using Optivem.EShop.SystemTest.Core.Shop.Dsl.Verifications;

namespace Dsl.Gherkin.Then;

public class ThenSuccessAssertionCoupon<TSuccessResponse, TSuccessVerification>
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    private readonly ThenClause<TSuccessResponse, TSuccessVerification> _thenClause;
    private readonly Func<Task<string>> _couponCodeFactory;
    private readonly List<Action<BrowseCouponsVerification, string>> _verifications = [];

    internal ThenSuccessAssertionCoupon(
        ThenClause<TSuccessResponse, TSuccessVerification> thenClause,
        Func<Task<string>> couponCodeFactory)
    {
        _thenClause = thenClause;
        _couponCodeFactory = couponCodeFactory;
    }

    public ThenSuccessAssertionCoupon<TSuccessResponse, TSuccessVerification> HasDiscountRate(decimal discountRate)
    {
        _verifications.Add((v, code) => v.CouponHasDiscountRate(code, discountRate));
        return this;
    }

    public ThenSuccessAssertionCoupon<TSuccessResponse, TSuccessVerification> IsValidFrom(string validFrom)
    {
        _verifications.Add((v, code) => v.CouponHasValidFrom(code, validFrom));
        return this;
    }

    public ThenSuccessAssertionCoupon<TSuccessResponse, TSuccessVerification> IsValidTo(string validTo)
    {
        _verifications.Add((v, code) => v.CouponHasValidTo(code, validTo));
        return this;
    }

    public ThenSuccessAssertionCoupon<TSuccessResponse, TSuccessVerification> HasUsageLimit(int usageLimit)
    {
        _verifications.Add((v, code) => v.CouponHasUsageLimit(code, usageLimit));
        return this;
    }

    public ThenSuccessAssertionCoupon<TSuccessResponse, TSuccessVerification> HasUsedCount(int expectedUsedCount)
    {
        _verifications.Add((v, code) => v.CouponHasUsedCount(code, expectedUsedCount));
        return this;
    }

    public TaskAwaiter GetAwaiter() => Execute().GetAwaiter();

    private async Task Execute()
    {
        var result = await _thenClause.GetExecutionResult();
        _ = result.Result.ShouldSucceed();

        var couponCode = await _couponCodeFactory();
        var shop = await _thenClause.App.Shop(_thenClause.Channel);
        var browseResult = await shop.BrowseCoupons().Execute();
        var verification = browseResult.ShouldSucceed();
        verification.HasCouponWithCode(couponCode);

        foreach (var v in _verifications)
        {
            v(verification, couponCode);
        }
    }
}
