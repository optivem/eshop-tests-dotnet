using Commons.Dsl;
using Dsl.Gherkin;
using Optivem.EShop.SystemTest.Core.Common.Dsl;

namespace Dsl.Gherkin.Then;

/// <summary>
/// Coupon verification in failure path - no success check, runs failure assertions first then coupon verifications.
/// </summary>
public class ThenFailureCouponVerifier<TSuccessResponse, TSuccessVerification>
    : BaseThenCouponVerifier<TSuccessResponse, TSuccessVerification, ThenFailureCouponVerifier<TSuccessResponse, TSuccessVerification>>
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    private readonly List<Action<SystemErrorFailureVerification>> _failureAssertions;

    internal ThenFailureCouponVerifier(
        ThenClause<TSuccessResponse, TSuccessVerification> thenClause,
        List<Action<SystemErrorFailureVerification>> failureAssertions,
        Func<Task<string>> couponCodeFactory)
        : base(thenClause, couponCodeFactory)
    {
        _failureAssertions = failureAssertions;
    }

    protected override Task RunPrelude(ExecutionResult<TSuccessResponse, TSuccessVerification> result)
    {
        if (result.Result == null)
            throw new InvalidOperationException("Cannot verify failure: no operation was executed");
        var failureVerification = result.Result.ShouldFail();
        foreach (var assertion in _failureAssertions)
        {
            assertion(failureVerification);
        }
        return Task.CompletedTask;
    }
}
