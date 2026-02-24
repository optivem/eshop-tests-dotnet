using Commons.Util;
using Optivem.EShop.SystemTest.Driver.Ports.Shop.Dtos;
using Optivem.EShop.SystemTest.Driver.Ports.Shop.Dtos.Error;

namespace Optivem.EShop.SystemTest.Driver.Ports.Shop;

public interface IShopDriver : IAsyncDisposable
{
    Task<Result<VoidValue, SystemError>> GoToShopAsync();
    Task<Result<PlaceOrderResponse, SystemError>> PlaceOrderAsync(PlaceOrderRequest request);
    Task<Result<VoidValue, SystemError>> CancelOrderAsync(string? orderNumber);
    Task<Result<ViewOrderResponse, SystemError>> ViewOrderAsync(string? orderNumber);
    Task<Result<VoidValue, SystemError>> PublishCouponAsync(PublishCouponRequest request);
    Task<Result<BrowseCouponsResponse, SystemError>> BrowseCouponsAsync();
}
