using Dsl.Api.Then.Steps;
using Dsl.Common;
using DslImpl.Scenario;

namespace DslImpl.Scenario.Then;

public class ThenSuccessOrder<TSuccessResponse, TSuccessVerification>
    : BaseThenResultOrder<TSuccessResponse, TSuccessVerification, ThenSuccessOrder<TSuccessResponse, TSuccessVerification>>, IThenOrder
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    internal ThenSuccessOrder(
        ThenStage<TSuccessResponse, TSuccessVerification> thenClause,
        Func<Task<string>> orderNumberFactory)
        : base(thenClause, orderNumberFactory)
    {
    }

    protected override Task RunPrelude(ExecutionResult<TSuccessResponse, TSuccessVerification> result)
    {
        _ = result.Result.ShouldSucceed();
        return Task.CompletedTask;
    }
}
