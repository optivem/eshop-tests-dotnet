using Commons.Dsl;

namespace Dsl.Gherkin.Then;

public class ThenSuccessAndVerifier<TSuccessResponse, TSuccessVerification>
    : BaseThenAndVerifier<TSuccessResponse, TSuccessVerification, ThenSuccessOrderVerifier<TSuccessResponse, TSuccessVerification>>
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    internal ThenSuccessAndVerifier(ThenClause<TSuccessResponse, TSuccessVerification> thenClause)
        : base(thenClause)
    {
    }

    protected override ThenSuccessOrderVerifier<TSuccessResponse, TSuccessVerification> CreateOrderAssertion(Func<Task<string>> orderNumberFactory)
    {
        return new ThenSuccessOrderVerifier<TSuccessResponse, TSuccessVerification>(_thenClause, orderNumberFactory);
    }

    public ThenSuccessCouponVerifier<TSuccessResponse, TSuccessVerification> Coupon(string couponCode)
    {
        return new ThenSuccessCouponVerifier<TSuccessResponse, TSuccessVerification>(
            _thenClause,
            () => Task.FromResult(couponCode));
    }

    /// <summary>
    /// Verifies coupon from execution result (coupon code from the executed operation).
    /// </summary>
    public ThenSuccessCouponVerifier<TSuccessResponse, TSuccessVerification> Coupon()
    {
        return new ThenSuccessCouponVerifier<TSuccessResponse, TSuccessVerification>(
            _thenClause,
            async () =>
            {
                var result = await _thenClause.GetExecutionResult();
                return result.CouponCode ?? throw new InvalidOperationException("Cannot verify coupon: no coupon code available from the executed operation");
            });
    }
}
