using Optivem.EShop.SystemTest.Core.Shop.Driver.Dtos.Orders;
using Optivem.EShop.SystemTest.Core.Shop.Driver.Dtos.Error;
using Commons.Util;

namespace Optivem.EShop.SystemTest.Core.Shop.Driver;

public interface IOrderDriver
{
    Task<Result<PlaceOrderResponse, SystemError>> PlaceOrderAsync(PlaceOrderRequest request);
    Task<Result<VoidValue, SystemError>> CancelOrderAsync(string? orderNumber);
    Task<Result<ViewOrderResponse, SystemError>> ViewOrderAsync(string? orderNumber);
}