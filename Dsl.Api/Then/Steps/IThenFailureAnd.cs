namespace Dsl.Api.Then.Steps;

public interface IThenFailureAnd
{
    IThenOrderAssertion Order(string orderNumber);

    IThenOrderAssertion Order();

    IThenCouponAssertion Coupon(string couponCode);

    IThenCouponAssertion Coupon();
}