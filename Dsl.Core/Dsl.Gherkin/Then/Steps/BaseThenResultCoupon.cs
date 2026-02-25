using System.Runtime.CompilerServices;
using Dsl.Api.Then.Steps;
using Driver.Shared.Dsl;
using DslImpl.Gherkin;
using Optivem.EShop.SystemTest.Core;
using Optivem.EShop.SystemTest.Core.Shop.Dsl.UseCases;

namespace DslImpl.Gherkin.Then;

public abstract class BaseThenResultCoupon<TSuccessResponse, TSuccessVerification, TDerived>
    : IThenCouponAssertion
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
    where TDerived : BaseThenResultCoupon<TSuccessResponse, TSuccessVerification, TDerived>
{
    protected readonly ThenClause<TSuccessResponse, TSuccessVerification> _thenClause;
    protected readonly Func<Task<string>> _couponCodeFactory;
    protected readonly List<Action<BrowseCouponsVerification, string>> _verifications = [];

    protected BaseThenResultCoupon(
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

    IThenCouponAssertion IThenCouponAssertion.HasDiscountRate(decimal discountRate) => HasDiscountRate(discountRate);

    public TDerived IsValidFrom(string validFrom)
    {
        _verifications.Add((v, code) => v.CouponHasValidFrom(code, validFrom));
        return Self;
    }

    IThenCouponAssertion IThenCouponAssertion.IsValidFrom(string validFrom) => IsValidFrom(validFrom);

    public TDerived IsValidTo(string validTo)
    {
        _verifications.Add((v, code) => v.CouponHasValidTo(code, validTo));
        return Self;
    }

    IThenCouponAssertion IThenCouponAssertion.IsValidTo(string validTo) => IsValidTo(validTo);

    public TDerived HasUsageLimit(int usageLimit)
    {
        _verifications.Add((v, code) => v.CouponHasUsageLimit(code, usageLimit));
        return Self;
    }

    IThenCouponAssertion IThenCouponAssertion.HasUsageLimit(int usageLimit) => HasUsageLimit(usageLimit);

    public TDerived HasUsedCount(int expectedUsedCount)
    {
        _verifications.Add((v, code) => v.CouponHasUsedCount(code, expectedUsedCount));
        return Self;
    }

    IThenCouponAssertion IThenCouponAssertion.HasUsedCount(int expectedUsedCount) => HasUsedCount(expectedUsedCount);

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
