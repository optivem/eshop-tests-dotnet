using Commons.Dsl;
using Optivem.EShop.SystemTest.Core.Common.Dsl;

namespace Dsl.Gherkin.Then;

public class ThenFailureAssertionAnd<TSuccessResponse, TSuccessVerification>
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    private readonly ThenClause<TSuccessResponse, TSuccessVerification> _thenClause;
    private readonly List<Action<SystemErrorFailureVerification>> _failureAssertions;

    internal ThenFailureAssertionAnd(
        ThenClause<TSuccessResponse, TSuccessVerification> thenClause,
        List<Action<SystemErrorFailureVerification>> failureAssertions)
    {
        _thenClause = thenClause;
        _failureAssertions = failureAssertions;
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> Order(string orderNumber)
    {
        return new ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification>(
            _thenClause,
            _failureAssertions,
            () => Task.FromResult(orderNumber));
    }

    public ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification> Order()
    {
        return new ThenFailureAssertionOrder<TSuccessResponse, TSuccessVerification>(
            _thenClause,
            _failureAssertions,
            async () =>
            {
                var result = await _thenClause.GetExecutionResult();
                return result.OrderNumber ?? throw new InvalidOperationException("Cannot verify order: no order number available from the executed operation");
            });
    }
}
