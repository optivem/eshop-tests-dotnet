using Commons.Dsl;
using Optivem.Testing;

namespace Dsl.Gherkin.Then;

public abstract class BaseThenBuilder<TSuccessResponse, TSuccessVerification>
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    protected readonly ThenClause<TSuccessResponse, TSuccessVerification> _thenClause;

    protected BaseThenBuilder(ThenClause<TSuccessResponse, TSuccessVerification> thenClause)
    {
        _thenClause = thenClause;
    }

    public BaseThenBuilder<TSuccessResponse, TSuccessVerification> And()
    {
        return this;
    }

    public ThenOrderBuilder<TSuccessResponse, TSuccessVerification> Order(string orderNumber)
    {
        return new ThenOrderBuilder<TSuccessResponse, TSuccessVerification>(_thenClause, _thenClause.App, orderNumber);
    }

    public async Task<ThenOrderBuilder<TSuccessResponse, TSuccessVerification>> Order()
    {
        var result = await _thenClause.GetExecutionResult();
        var orderNumber = result.OrderNumber;

        if (orderNumber == null)
        {
            throw new InvalidOperationException("Cannot verify order: no order number available from the executed operation");
        }

        return Order(orderNumber);
    }

    public ThenCouponBuilder<TSuccessResponse, TSuccessVerification> Coupon(string couponCode)
    {
        return new ThenCouponBuilder<TSuccessResponse, TSuccessVerification>(_thenClause, _thenClause.App, couponCode);
    }

    public async Task<ThenCouponBuilder<TSuccessResponse, TSuccessVerification>> Coupon()
    {
        var result = await _thenClause.GetExecutionResult();
        var couponCode = result.CouponCode;

        if (couponCode == null)
        {
            throw new InvalidOperationException("Cannot verify coupon: no coupon code available from the executed operation");
        }

        return Coupon(couponCode);
    }

    protected Channel Channel => _thenClause.Channel;
}