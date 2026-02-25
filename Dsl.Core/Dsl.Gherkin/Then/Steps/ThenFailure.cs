using System.Runtime.CompilerServices;
using Dsl.Api.Then.Steps;
using Driver.Shared.Dsl;
using Optivem.EShop.SystemTest.Core.Shop.Dsl.UseCases.Base;

namespace DslImpl.Gherkin.Then;

/// <summary>
/// Deferred failure assertion - allows chaining ErrorMessage/FieldErrorMessage before awaiting.
/// Enables fluent syntax: await Scenario(...).Then().ShouldFail().ErrorMessage("...").FieldErrorMessage("...");
/// </summary>
public class ThenFailureVerifier<TSuccessResponse, TSuccessVerification>
    : IThenFailureVerifier
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    private readonly ThenStage<TSuccessResponse, TSuccessVerification> _thenClause;
    private readonly List<Action<SystemErrorFailureVerification>> _assertions = [];

    internal ThenFailureVerifier(ThenStage<TSuccessResponse, TSuccessVerification> thenClause)
    {
        _thenClause = thenClause;
    }

    public ThenFailureVerifier<TSuccessResponse, TSuccessVerification> ErrorMessage(string expectedMessage)
    {
        _assertions.Add(v => v.ErrorMessage(expectedMessage));
        return this;
    }

    IThenFailureVerifier IThenFailureVerifier.ErrorMessage(string expectedMessage) => ErrorMessage(expectedMessage);

    public ThenFailureVerifier<TSuccessResponse, TSuccessVerification> FieldErrorMessage(string expectedField, string expectedMessage)
    {
        _assertions.Add(v => v.FieldErrorMessage(expectedField, expectedMessage));
        return this;
    }

    IThenFailureVerifier IThenFailureVerifier.FieldErrorMessage(string expectedField, string expectedMessage)
        => FieldErrorMessage(expectedField, expectedMessage);

    /// <summary>
    /// Returns the failure assertion and for further chaining (e.g. .And().Order().HasStatus(...)).
    /// Enables fluent syntax: await Scenario(...).Then().ShouldFail().ErrorMessage("...").And().Order().HasStatus(...);
    /// </summary>
    public ThenFailureAnd<TSuccessResponse, TSuccessVerification> And()
    {
        return new ThenFailureAnd<TSuccessResponse, TSuccessVerification>(_thenClause, _assertions);
    }

    IThenFailureAnd IThenFailureVerifier.And() => And();

    public TaskAwaiter GetAwaiter() => ExecuteAssertions().GetAwaiter();

    private async Task ExecuteAssertions()
    {
        var result = await _thenClause.GetExecutionResult();
        if (result.Result == null)
            throw new InvalidOperationException("Cannot verify failure: no operation was executed");
        var failureVerification = result.Result.ShouldFail();
        foreach (var assertion in _assertions)
        {
            assertion(failureVerification);
        }
    }
}
