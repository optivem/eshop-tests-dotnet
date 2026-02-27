using Common;
using D;
using D;

namespace Driver.Api.Shop;

public interface IShopDriver : IAsyncDisposable
{
    Task<Result<VoidValue, SystemError>> GoToShopAsync();
    Task<Result<PlaceOrderResponse, SystemError>> PlaceOrderAsync(PlaceOrderRequest request);
    Task<Result<VoidValue, SystemError>> CancelOrderAsync(string? orderNumber);
    Task<Result<ViewOrderResponse, SystemError>> ViewOrderAsync(string? orderNumber);
    Task<Result<VoidValue, SystemError>> PublishCouponAsync(PublishCouponRequest request);
    Task<Result<BrowseCouponsResponse, SystemError>> BrowseCouponsAsync();
}
