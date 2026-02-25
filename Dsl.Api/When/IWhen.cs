using Dsl.Api.When.Steps;

namespace Dsl.Api.When;

public interface IWhen
{
    IGoToShopBuilder GoToShop();

    IPlaceOrderBuilder PlaceOrder();

    ICancelOrderBuilder CancelOrder();

    IViewOrderBuilder ViewOrder();

    IPublishCouponBuilder PublishCoupon();

    IBrowseCouponsBuilder BrowseCoupons();
}