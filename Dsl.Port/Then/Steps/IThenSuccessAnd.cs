namespace Dsl.Api.Then.Steps;

public interface IThenSuccessAnd
{
    IThenOrder Order(string orderNumber);

    IThenOrder Order();

    IThenCoupon Coupon(string couponCode);

    IThenCoupon Coupon();
}