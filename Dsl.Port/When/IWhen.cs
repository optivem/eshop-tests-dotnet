using Dsl.Port.When.Steps;

namespace Dsl.Port.When;

public interface IWhen
{
    IGoToShop GoToShop();

    IPlaceOrder PlaceOrder();

    ICancelOrder CancelOrder();

    IViewOrder ViewOrder();

    IPublishCoupon PublishCoupon();

    IBrowseCoupons BrowseCoupons();
}
