using Dsl.Api.Then.Steps;
using Driver.Shared.Dsl;
using DslImpl.Gherkin;

namespace DslImpl.Gherkin.Then;

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
