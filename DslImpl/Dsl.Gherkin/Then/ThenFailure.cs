using System.Runtime.CompilerServices;
using Driver.Impl.Commons.Dsl;
using Optivem.EShop.SystemTest.Core.Shop.Dsl.UseCases.Base;

namespace DslImpl.Gherkin.Then;

/// <summary>
/// Deferred failure assertion - allows chaining ErrorMessage/FieldErrorMessage before awaiting.
/// Enables fluent syntax: await Scenario(...).Then().ShouldFail().ErrorMessage("...").FieldErrorMessage("...");
/// </summary>
public class ThenFailureVerifier<TSuccessResponse, TSuccessVerification>
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    private readonly ThenClause<TSuccessResponse, TSuccessVerification> _thenClause;
    private readonly List<Action<SystemErrorFailureVerification>> _assertions = [];

    internal ThenFailureVerifier(ThenClause<TSuccessResponse, TSuccessVerification> thenClause)
    {
        _thenClause = thenClause;
    }

    public ThenFailureVerifier<TSuccessResponse, TSuccessVerification> ErrorMessage(string expectedMessage)
    {
        _assertions.Add(v => v.ErrorMessage(expectedMessage));
        return this;
    }

    public ThenFailureVerifier<TSuccessResponse, TSuccessVerification> FieldErrorMessage(string expectedField, string expectedMessage)
    {
        _assertions.Add(v => v.FieldErrorMessage(expectedField, expectedMessage));
        return this;
    }

    /// <summary>
    /// Returns the failure assertion and for further chaining (e.g. .And().Order().HasStatus(...)).
    /// Enables fluent syntax: await Scenario(...).Then().ShouldFail().ErrorMessage("...").And().Order().HasStatus(...);
    /// </summary>
    public ThenFailureAnd<TSuccessResponse, TSuccessVerification> And()
    {
        return new ThenFailureAnd<TSuccessResponse, TSuccessVerification>(_thenClause, _assertions);
    }

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
