using Dsl.Port.Then.Steps;
using Dsl.Common;
using Dsl.Core.Shop.UseCases.Base;

namespace Dsl.Core.Scenario.Then;

public class ThenFailureAnd<TSuccessResponse, TSuccessVerification>
    : BaseThenAnd<TSuccessResponse, TSuccessVerification, ThenFailureOrder<TSuccessResponse, TSuccessVerification>>, IThenFailureAnd
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    private readonly List<Action<SystemErrorFailureVerification>> _failureAssertions;

    internal ThenFailureAnd(
        ThenStage<TSuccessResponse, TSuccessVerification> thenClause,
        List<Action<SystemErrorFailureVerification>> failureAssertions)
        : base(thenClause)
    {
        _failureAssertions = failureAssertions;
    }

    protected override ThenFailureOrder<TSuccessResponse, TSuccessVerification> CreateOrderAssertion(Func<Task<string>> orderNumberFactory)
    {
        return new ThenFailureOrder<TSuccessResponse, TSuccessVerification>(_thenClause, _failureAssertions, orderNumberFactory);
    }

    public ThenFailureCoupon<TSuccessResponse, TSuccessVerification> Coupon(string couponCode)
    {
        return new ThenFailureCoupon<TSuccessResponse, TSuccessVerification>(
            _thenClause,
            _failureAssertions,
            () => Task.FromResult(couponCode));
    }

    IThenCoupon IThenFailureAnd.Coupon(string couponCode) => Coupon(couponCode);

    /// <summary>
    /// Verifies coupon from execution result (coupon code from the executed operation).
    /// </summary>
    public ThenFailureCoupon<TSuccessResponse, TSuccessVerification> Coupon()
    {
        return new ThenFailureCoupon<TSuccessResponse, TSuccessVerification>(
            _thenClause,
            _failureAssertions,
            async () =>
            {
                var result = await _thenClause.GetExecutionResult();
                return result.CouponCode ?? throw new InvalidOperationException("Cannot verify coupon: no coupon code available from the executed operation");
            });
    }

    IThenCoupon IThenFailureAnd.Coupon() => Coupon();

    IThenOrder IThenFailureAnd.Order(string orderNumber) => Order(orderNumber);

    IThenOrder IThenFailureAnd.Order() => Order();
}


