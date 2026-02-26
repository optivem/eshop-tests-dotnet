using Dsl.Api.When.Steps;

namespace Dsl.Api.When;

public interface IWhen
{
    IGoToShop GoToShop();

    IPlaceOrder PlaceOrder();

    ICancelOrder CancelOrder();

    IViewOrder ViewOrder();

    IPublishCoupon PublishCoupon();

    IBrowseCoupons BrowseCoupons();
}