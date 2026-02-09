using Commons.Dsl;

namespace Dsl.Gherkin.Then;

public class ThenFailureAssertionAnd<TSuccessResponse, TSuccessVerification>
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    private readonly ThenClause<TSuccessResponse, TSuccessVerification> _thenClause;
    private readonly List<Action<ThenFailureBuilder<TSuccessResponse, TSuccessVerification>>> _failureAssertions;

    internal ThenFailureAssertionAnd(
        ThenClause<TSuccessResponse, TSuccessVerification> thenClause,
        List<Action<ThenFailureBuilder<TSuccessResponse, TSuccessVerification>>> failureAssertions)
    {
        _thenClause = thenClause;
        _failureAssertions = failureAssertions;
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> Order(string orderNumber)
    {
        return new ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification>(
            _thenClause,
            _failureAssertions,
            () => Task.FromResult(new ThenOrderBuilder<TSuccessResponse, TSuccessVerification>(_thenClause, _thenClause.App, orderNumber)));
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> Order()
    {
        return new ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification>(
            _thenClause,
            _failureAssertions,
            async () =>
            {
                var result = await _thenClause.GetExecutionResult();
                var orderNumber = result.OrderNumber ?? throw new InvalidOperationException("Cannot verify order: no order number available from the executed operation");
                return new ThenOrderBuilder<TSuccessResponse, TSuccessVerification>(_thenClause, _thenClause.App, orderNumber);
            });
    }
}
