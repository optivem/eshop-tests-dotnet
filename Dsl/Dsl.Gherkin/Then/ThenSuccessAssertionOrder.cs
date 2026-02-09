using Commons.Dsl;
using Dsl.Gherkin;

namespace Dsl.Gherkin.Then;

public class ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification>
    : BaseThenAssertionOrder<TSuccessResponse, TSuccessVerification, ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification>>
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    internal ThenSuccessAssertionOrder(
        ThenClause<TSuccessResponse, TSuccessVerification> thenClause,
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
