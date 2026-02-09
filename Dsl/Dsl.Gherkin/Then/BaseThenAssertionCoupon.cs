using System.Runtime.CompilerServices;
using Commons.Dsl;
using Dsl.Gherkin;
using Optivem.EShop.SystemTest.Core;
using Optivem.EShop.SystemTest.Core.Shop.Dsl.Verifications;

namespace Dsl.Gherkin.Then;

public abstract class BaseThenAssertionCoupon<TSuccessResponse, TSuccessVerification, TDerived>
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
    where TDerived : BaseThenAssertionCoupon<TSuccessResponse, TSuccessVerification, TDerived>
{
    protected readonly ThenClause<TSuccessResponse, TSuccessVerification> _thenClause;
    protected readonly Func<Task<string>> _couponCodeFactory;
    protected readonly List<Action<BrowseCouponsVerification, string>> _verifications = [];

    protected BaseThenAssertionCoupon(
        ThenClause<TSuccessResponse, TSuccessVerification> thenClause,
        Func<Task<string>> couponCodeFactory)
    {
        _thenClause = thenClause;
        _couponCodeFactory = couponCodeFactory;
    }

    protected abstract Task RunPrelude(ExecutionResult<TSuccessResponse, TSuccessVerification> result);

    protected TDerived Self => (TDerived)this;

    public TDerived HasDiscountRate(decimal discountRate)
    {
        _verifications.Add((v, code) => v.CouponHasDiscountRate(code, discountRate));
        return Self;
    }

    public TDerived IsValidFrom(string validFrom)
    {
        _verifications.Add((v, code) => v.CouponHasValidFrom(code, validFrom));
        return Self;
    }

    public TDerived IsValidTo(string validTo)
    {
        _verifications.Add((v, code) => v.CouponHasValidTo(code, validTo));
        return Self;
    }

    public TDerived HasUsageLimit(int usageLimit)
    {
        _verifications.Add((v, code) => v.CouponHasUsageLimit(code, usageLimit));
        return Self;
    }

    public TDerived HasUsedCount(int expectedUsedCount)
    {
        _verifications.Add((v, code) => v.CouponHasUsedCount(code, expectedUsedCount));
        return Self;
    }

    public TaskAwaiter GetAwaiter() => Execute().GetAwaiter();

    private async Task Execute()
    {
        var result = await _thenClause.GetExecutionResult();
        await RunPrelude(result);

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
