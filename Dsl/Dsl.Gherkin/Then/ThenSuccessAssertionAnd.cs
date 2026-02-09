using Commons.Dsl;

namespace Dsl.Gherkin.Then;

public class ThenSuccessAssertionAnd<TSuccessResponse, TSuccessVerification>
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    private readonly ThenClause<TSuccessResponse, TSuccessVerification> _thenClause;

    internal ThenSuccessAssertionAnd(ThenClause<TSuccessResponse, TSuccessVerification> thenClause)
    {
        _thenClause = thenClause;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> Order(string orderNumber)
    {
        return new ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification>(
            _thenClause,
            () => Task.FromResult(orderNumber));
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> Order()
    {
        return new ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification>(
            _thenClause,
            async () =>
            {
                var result = await _thenClause.GetExecutionResult();
                return result.OrderNumber ?? throw new InvalidOperationException("Cannot verify order: no order number available from the executed operation");
            });
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
