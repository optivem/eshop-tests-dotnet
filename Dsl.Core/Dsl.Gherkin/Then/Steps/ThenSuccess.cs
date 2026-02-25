using System.Runtime.CompilerServices;
using Dsl.Api.Then.Steps;
using Driver.Shared.Dsl;

namespace DslImpl.Gherkin.Then;

/// <summary>
/// Deferred success assertion builder - allows chaining .And().Order().HasStatus(...) before awaiting.
/// Enables fluent syntax: await Scenario(...).Then().ShouldSucceed().And().Order().HasStatus(...);
/// </summary>
public class ThenSuccessVerifier<TSuccessResponse, TSuccessVerification>
    : IThenSuccessVerifier
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    private readonly ThenStage<TSuccessResponse, TSuccessVerification> _thenClause;

    internal ThenSuccessVerifier(ThenStage<TSuccessResponse, TSuccessVerification> thenClause)
    {
        _thenClause = thenClause;
    }

    public ThenSuccessAnd<TSuccessResponse, TSuccessVerification> And()
    {
        return new ThenSuccessAnd<TSuccessResponse, TSuccessVerification>(_thenClause);
    }

    IThenSuccessAnd IThenSuccessVerifier.And() => And();

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
