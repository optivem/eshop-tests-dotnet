using Commons.Dsl;
using Optivem.EShop.SystemTest.Core.Gherkin.Then;

namespace Dsl.Gherkin.Then;

public class ThenSuccessAssertionAnd<TSuccessResponse, TSuccessVerification>
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    private readonly ThenClause<TSuccessResponse, TSuccessVerification> _thenClause;

    internal ThenSuccessAssertionAnd(ThenClause<TSuccessResponse, TSuccessVerification> thenClause)
    {
        _thenClause = thenClause;
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> Order(string orderNumber)
    {
        return new ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification>(
            _thenClause,
            () => Task.FromResult(new ThenOrderBuilder<TSuccessResponse, TSuccessVerification>(_thenClause, _thenClause.App, orderNumber)));
    }

    public ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification> Order()
    {
        return new ThenSuccessAssertionOrder<TSuccessResponse, TSuccessVerification>(
            _thenClause,
            async () =>
            {
                var result = await _thenClause.GetExecutionResult();
                var orderNumber = result.OrderNumber ?? throw new InvalidOperationException("Cannot verify order: no order number available from the executed operation");
                return new ThenOrderBuilder<TSuccessResponse, TSuccessVerification>(_thenClause, _thenClause.App, orderNumber);
            });
    }

    public ThenSuccessAssertionCoupon<TSuccessResponse, TSuccessVerification> Coupon(string couponCode)
    {
        return new ThenSuccessAssertionCoupon<TSuccessResponse, TSuccessVerification>(
            _thenClause,
            new ThenCouponBuilder<TSuccessResponse, TSuccessVerification>(_thenClause, _thenClause.App, couponCode));
    }
}
