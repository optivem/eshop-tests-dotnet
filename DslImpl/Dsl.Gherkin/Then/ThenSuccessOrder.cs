using Driver.Impl.Commons.Dsl;
using DslImpl.Gherkin;

namespace DslImpl.Gherkin.Then;

public class ThenSuccessOrderVerifier<TSuccessResponse, TSuccessVerification>
    : BaseThenResultOrder<TSuccessResponse, TSuccessVerification, ThenSuccessOrderVerifier<TSuccessResponse, TSuccessVerification>>
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    internal ThenSuccessOrderVerifier(
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
