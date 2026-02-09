using Commons.Dsl;

namespace Dsl.Gherkin.Then;

public class ThenSuccessAssertionAnd<TSuccessResponse, TSuccessVerification>
    : BaseThenAssertionAnd<TSuccessResponse, TSuccessVerification, ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification>>
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    internal ThenSuccessAssertionAnd(ThenClause<TSuccessResponse, TSuccessVerification> thenClause)
        : base(thenClause)
    {
    }

    protected override ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> CreateOrderAssertion(Func<Task<string>> orderNumberFactory)
    {
        return new ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification>(_thenClause, orderNumberFactory);
    }

    public ThenSuccessAssertionCoupon<TSuccessResponse, TSuccessVerification> Coupon(string couponCode)
    {
        return new ThenSuccessAssertionCoupon<TSuccessResponse, TSuccessVerification>(
            _thenClause,
            () => Task.FromResult(couponCode));
    }

    /// <summary>
    /// Verifies coupon from execution result (coupon code from the executed operation).
    /// Aligns with Java BaseThenBuilder.coupon().
    /// </summary>
    public ThenSuccessAssertionCoupon<TSuccessResponse, TSuccessVerification> Coupon()
    {
        return new ThenSuccessAssertionCoupon<TSuccessResponse, TSuccessVerification>(
            _thenClause,
            async () =>
            {
                var result = await _thenClause.GetExecutionResult();
                return result.CouponCode ?? throw new InvalidOperationException("Cannot verify coupon: no coupon code available from the executed operation");
            });
    }
}
