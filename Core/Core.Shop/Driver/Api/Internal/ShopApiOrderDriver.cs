using Commons.Util;
using Optivem.EShop.SystemTest.Core.Shop.Client.Api;
using Optivem.EShop.SystemTest.Core.Shop.Commons.Dtos.Orders;
using Optivem.EShop.SystemTest.Core.Shop.Commons.Dtos.Errors;
using Optivem.EShop.SystemTest.Core.Shop.Driver.Internal;

namespace Optivem.EShop.SystemTest.Core.Shop.Driver.Api.Internal;

public class ShopApiOrderDriver : IOrderDriver
{
    private readonly ShopApiClient _apiClient;

    public ShopApiOrderDriver(ShopApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public Task<Result<PlaceOrderResponse, SystemError>> PlaceOrderAsync(PlaceOrderRequest request)
        => _apiClient.Orders().PlaceOrderAsync(request)
            .MapErrorAsync(SystemError.From);

    public Task<Result<VoidValue, SystemError>> CancelOrderAsync(string? orderNumber)
        => _apiClient.Orders().CancelOrderAsync(orderNumber)
            .MapErrorAsync(SystemError.From);

    public Task<Result<ViewOrderResponse, SystemError>> ViewOrderAsync(string? orderNumber)
        => _apiClient.Orders().ViewOrderAsync(orderNumber)
            .MapErrorAsync(SystemError.From);
}