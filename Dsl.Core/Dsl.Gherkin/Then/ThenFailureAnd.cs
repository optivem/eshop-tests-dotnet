using Driver.Core.Driver.Commons.Dsl;
using Optivem.EShop.SystemTest.Dsl.Shop.Dsl.UseCases.Base;

namespace Dsl.Gherkin.Then;

public class ThenFailureAnd<TSuccessResponse, TSuccessVerification>
    : BaseThenAndVerifier<TSuccessResponse, TSuccessVerification, ThenFailureOrder<TSuccessResponse, TSuccessVerification>>
    where TSuccessVerification : Driver.Core.Driver.Commons.Dsl.ResponseVerification<TSuccessResponse>
{
    private readonly List<Action<SystemErrorFailureVerification>> _failureAssertions;

    internal ThenFailureAnd(
        ThenClause<TSuccessResponse, TSuccessVerification> thenClause,
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
}
