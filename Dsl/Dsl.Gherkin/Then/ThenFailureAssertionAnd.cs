using Commons.Dsl;
using Optivem.EShop.SystemTest.Core.Common.Dsl;

namespace Dsl.Gherkin.Then;

public class ThenFailureAssertionAnd<TSuccessResponse, TSuccessVerification>
    : BaseThenAssertionAnd<TSuccessResponse, TSuccessVerification, ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification>>
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    private readonly List<Action<SystemErrorFailureVerification>> _failureAssertions;

    internal ThenFailureAssertionAnd(
        ThenClause<TSuccessResponse, TSuccessVerification> thenClause,
        List<Action<SystemErrorFailureVerification>> failureAssertions)
        : base(thenClause)
    {
        _failureAssertions = failureAssertions;
    }

    protected override ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> CreateOrderAssertion(Func<Task<string>> orderNumberFactory)
    {
        return new ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification>(_thenClause, _failureAssertions, orderNumberFactory);
    }

    public ThenFailureAssertionCoupon<TSuccessResponse, TSuccessVerification> Coupon(string couponCode)
    {
        return new ThenFailureAssertionCoupon<TSuccessResponse, TSuccessVerification>(
            _thenClause,
            _failureAssertions,
            () => Task.FromResult(couponCode));
    }

    /// <summary>
    /// Verifies coupon from execution result (coupon code from the executed operation).
    /// </summary>
    public ThenFailureAssertionCoupon<TSuccessResponse, TSuccessVerification> Coupon()
    {
        return new ThenFailureAssertionCoupon<TSuccessResponse, TSuccessVerification>(
            _thenClause,
            _failureAssertions,
            async () =>
            {
                var result = await _thenClause.GetExecutionResult();
                return result.CouponCode ?? throw new InvalidOperationException("Cannot verify coupon: no coupon code available from the executed operation");
            });
    }
}
