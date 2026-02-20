using Commons.Dsl;

namespace Dsl.Gherkin.Then;

public abstract class BaseThenAndVerifier<TSuccessResponse, TSuccessVerification, TOrderAssertion>
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
    where TOrderAssertion : BaseThenResultOrder<TSuccessResponse, TSuccessVerification, TOrderAssertion>
{
    protected readonly ThenClause<TSuccessResponse, TSuccessVerification> _thenClause;

    protected BaseThenAndVerifier(ThenClause<TSuccessResponse, TSuccessVerification> thenClause)
    {
        _thenClause = thenClause;
    }

    protected abstract TOrderAssertion CreateOrderAssertion(Func<Task<string>> orderNumberFactory);

    public TOrderAssertion Order(string orderNumber)
    {
        return CreateOrderAssertion(() => Task.FromResult(orderNumber));
    }

    public TOrderAssertion Order()
    {
        return CreateOrderAssertion(async () =>
        {
            var result = await _thenClause.GetExecutionResult();
            return result.OrderNumber ?? throw new InvalidOperationException("Cannot verify order: no order number available from the executed operation");
        });
    }
}
