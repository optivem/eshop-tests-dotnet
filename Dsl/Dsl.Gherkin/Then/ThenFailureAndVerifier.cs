using Commons.Dsl;
using Optivem.EShop.SystemTest.Core.Shop.Dsl.UseCases.Base;

namespace Dsl.Gherkin.Then;

public class ThenFailureAndVerifier<TSuccessResponse, TSuccessVerification>
    : BaseThenAndVerifier<TSuccessResponse, TSuccessVerification, ThenFailureOrderVerifier<TSuccessResponse, TSuccessVerification>>
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    private readonly List<Action<SystemErrorFailureVerification>> _failureAssertions;

    internal ThenFailureAndVerifier(
        ThenClause<TSuccessResponse, TSuccessVerification> thenClause,
        List<Action<SystemErrorFailureVerification>> failureAssertions)
        : base(thenClause)
    {
        _failureAssertions = failureAssertions;
    }

    protected override ThenFailureOrderVerifier<TSuccessResponse, TSuccessVerification> CreateOrderAssertion(Func<Task<string>> orderNumberFactory)
    {
        return new ThenFailureOrderVerifier<TSuccessResponse, TSuccessVerification>(_thenClause, _failureAssertions, orderNumberFactory);
    }

    public ThenFailureCouponVerifier<TSuccessResponse, TSuccessVerification> Coupon(string couponCode)
    {
        return new ThenFailureCouponVerifier<TSuccessResponse, TSuccessVerification>(
            _thenClause,
            _failureAssertions,
            () => Task.FromResult(couponCode));
    }

    /// <summary>
    /// Verifies coupon from execution result (coupon code from the executed operation).
    /// </summary>
    public ThenFailureCouponVerifier<TSuccessResponse, TSuccessVerification> Coupon()
    {
        return new ThenFailureCouponVerifier<TSuccessResponse, TSuccessVerification>(
            _thenClause,
            _failureAssertions,
            async () =>
            {
                var result = await _thenClause.GetExecutionResult();
                return result.CouponCode ?? throw new InvalidOperationException("Cannot verify coupon: no coupon code available from the executed operation");
            });
    }
}
