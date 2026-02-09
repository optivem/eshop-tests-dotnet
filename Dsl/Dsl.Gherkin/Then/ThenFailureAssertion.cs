using System.Runtime.CompilerServices;
using Commons.Dsl;
using Optivem.EShop.SystemTest.Core.Shop.Dsl.Commands.Base;

namespace Dsl.Gherkin.Then;

/// <summary>
/// Deferred failure assertion builder - allows chaining ErrorMessage/FieldErrorMessage before awaiting.
/// Enables fluent syntax: await Scenario(...).Then().ShouldFail().ErrorMessage("...").FieldErrorMessage("...");
/// </summary>
public class ThenFailureAssertion<TSuccessResponse, TSuccessVerification>
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    private readonly ThenClause<TSuccessResponse, TSuccessVerification> _thenClause;
    private readonly List<Action<ThenFailureBuilder<TSuccessResponse, TSuccessVerification>>> _assertions = [];

    internal ThenFailureAssertion(ThenClause<TSuccessResponse, TSuccessVerification> thenClause)
    {
        _thenClause = thenClause;
    }

    public ThenFailureAssertion<TSuccessResponse, TSuccessVerification> ErrorMessage(string expectedMessage)
    {
        _assertions.Add(b => b.ErrorMessage(expectedMessage));
        return this;
    }

    public ThenFailureAssertion<TSuccessResponse, TSuccessVerification> FieldErrorMessage(string expectedField, string expectedMessage)
    {
        _assertions.Add(b => b.FieldErrorMessage(expectedField, expectedMessage));
        return this;
    }

    /// <summary>
    /// Returns the failure assertion and for further chaining (e.g. .And().Order().HasStatus(...)).
    /// Enables fluent syntax: await Scenario(...).Then().ShouldFail().ErrorMessage("...").And().Order().HasStatus(...);
    /// </summary>
    public ThenFailureAssertionAnd<TSuccessResponse, TSuccessVerification> And()
    {
        return new ThenFailureAssertionAnd<TSuccessResponse, TSuccessVerification>(_thenClause, _assertions);
    }

    public TaskAwaiter GetAwaiter() => ExecuteAssertions().GetAwaiter();

    private async Task ExecuteAssertions()
    {
        var result = await _thenClause.GetExecutionResult();
        var builder = new ThenFailureBuilder<TSuccessResponse, TSuccessVerification>(_thenClause, result.Result);
        foreach (var assertion in _assertions)
        {
            assertion(builder);
        }
    }
}
