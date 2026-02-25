namespace Dsl.Api.Then.Steps;

public interface IThenSuccessAnd
{
    IThenOrderAssertion Order(string orderNumber);

    IThenOrderAssertion Order();

    IThenCouponAssertion Coupon(string couponCode);

    IThenCouponAssertion Coupon();
}