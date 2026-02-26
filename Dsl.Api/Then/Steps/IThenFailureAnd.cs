namespace Dsl.Api.Then.Steps;

public interface IThenFailureAnd
{
    IThenOrder Order(string orderNumber);

    IThenOrder Order();

    IThenCoupon Coupon(string couponCode);

    IThenCoupon Coupon();
}