using Dsl.Api.Then.Steps;
using Driver.Shared.Dsl;

namespace DslImpl.Gherkin.Then;

public class ThenSuccessAnd<TSuccessResponse, TSuccessVerification>
    : BaseThenAnd<TSuccessResponse, TSuccessVerification, ThenSuccessOrder<TSuccessResponse, TSuccessVerification>>, IThenSuccessAnd
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    internal ThenSuccessAnd(ThenStage<TSuccessResponse, TSuccessVerification> thenClause)
        : base(thenClause)
    {
    }

    protected override ThenSuccessOrder<TSuccessResponse, TSuccessVerification> CreateOrderAssertion(Func<Task<string>> orderNumberFactory)
    {
        return new ThenSuccessOrder<TSuccessResponse, TSuccessVerification>(_thenClause, orderNumberFactory);
    }

    public ThenSuccessCoupon<TSuccessResponse, TSuccessVerification> Coupon(string couponCode)
    {
        return new ThenSuccessCoupon<TSuccessResponse, TSuccessVerification>(
            _thenClause,
            () => Task.FromResult(couponCode));
    }

    IThenCoupon IThenSuccessAnd.Coupon(string couponCode) => Coupon(couponCode);

    public ThenSuccessCoupon<TSuccessResponse, TSuccessVerification> Coupon()
    {
        return new ThenSuccessCoupon<TSuccessResponse, TSuccessVerification>(
            _thenClause,
            async () =>
            {
                var result = await _thenClause.GetExecutionResult();
                return result.CouponCode ?? throw new InvalidOperationException("Cannot verify coupon: no coupon code available from the executed operation");
            });
    }

    IThenCoupon IThenSuccessAnd.Coupon() => Coupon();

    IThenOrder IThenSuccessAnd.Order(string orderNumber) => Order(orderNumber);

    IThenOrder IThenSuccessAnd.Order() => Order();
}
