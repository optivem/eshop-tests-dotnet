using Dsl.Api.Then.Steps;
using Dsl.Common;
using DslImpl.Scenario;

namespace DslImpl.Scenario.Then;

public class ThenSuccessCoupon<TSuccessResponse, TSuccessVerification>
    : BaseThenResultCoupon<TSuccessResponse, TSuccessVerification, ThenSuccessCoupon<TSuccessResponse, TSuccessVerification>>, IThenCoupon
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    internal ThenSuccessCoupon(
        ThenStage<TSuccessResponse, TSuccessVerification> thenClause,
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
