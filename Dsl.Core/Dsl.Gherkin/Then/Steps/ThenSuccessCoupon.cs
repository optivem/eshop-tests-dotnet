using Dsl.Api.Then.Steps;
using Driver.Shared.Dsl;
using DslImpl.Gherkin;

namespace DslImpl.Gherkin.Then;

public class ThenSuccessCouponVerifier<TSuccessResponse, TSuccessVerification>
    : BaseThenResultCoupon<TSuccessResponse, TSuccessVerification, ThenSuccessCouponVerifier<TSuccessResponse, TSuccessVerification>>, IThenCouponAssertion
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    internal ThenSuccessCouponVerifier(
        ThenClause<TSuccessResponse, TSuccessVerification> thenClause,
        Func<Task<string>> couponCodeFactory)
        : base(thenClause, couponCodeFactory)
    {
    }

    protected override Task RunPrelude(ExecutionResult<TSuccessResponse, TSuccessVerification> result)
    {
        _ = result.Result.ShouldSucceed();
        return Task.CompletedTask;
    }
}
