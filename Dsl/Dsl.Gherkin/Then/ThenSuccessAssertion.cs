using System.Runtime.CompilerServices;
using Commons.Dsl;

namespace Dsl.Gherkin.Then;

/// <summary>
/// Deferred success assertion builder - allows chaining .And().Order().HasStatus(...) before awaiting.
/// Enables fluent syntax: await Scenario(...).Then().ShouldSucceed().And().Order().HasStatus(...);
/// </summary>
public class ThenSuccessAssertion<TSuccessResponse, TSuccessVerification>
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    private readonly ThenClause<TSuccessResponse, TSuccessVerification> _thenClause;

    internal ThenSuccessAssertion(ThenClause<TSuccessResponse, TSuccessVerification> thenClause)
    {
        _thenClause = thenClause;
    }

    public ThenSuccessAssertionAnd<TSuccessResponse, TSuccessVerification> And()
    {
        return new ThenSuccessAssertionAnd<TSuccessResponse, TSuccessVerification>(_thenClause);
    }

    /// <summary>
    /// When awaited with no further chaining, runs the success verification.
    /// </summary>
    public TaskAwaiter GetAwaiter() => ExecuteSuccessOnly().GetAwaiter();

    private async Task ExecuteSuccessOnly()
    {
        var result = await _thenClause.GetExecutionResult();
        _ = result.Result.ShouldSucceed();
    }
}
