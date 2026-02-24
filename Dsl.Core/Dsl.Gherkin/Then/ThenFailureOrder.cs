using Driver.Core.Driver.Commons.Dsl;
using Dsl.Gherkin;
using Optivem.EShop.SystemTest.Dsl.Shop.Dsl.UseCases.Base;

namespace Dsl.Gherkin.Then;

/// <summary>
/// Order verification in failure path - no success check, runs failure assertions first then order verifications.
/// </summary>
public class ThenFailureOrder<TSuccessResponse, TSuccessVerification>
    : BaseThenResultOrder<TSuccessResponse, TSuccessVerification, ThenFailureOrder<TSuccessResponse, TSuccessVerification>>
    where TSuccessVerification : Driver.Core.Driver.Commons.Dsl.ResponseVerification<TSuccessResponse>
{
    private readonly List<Action<SystemErrorFailureVerification>> _failureAssertions;

    internal ThenFailureOrder(
        ThenClause<TSuccessResponse, TSuccessVerification> thenClause,
        List<Action<SystemErrorFailureVerification>> failureAssertions,
        Func<Task<string>> orderNumberFactory)
        : base(thenClause, orderNumberFactory)
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
