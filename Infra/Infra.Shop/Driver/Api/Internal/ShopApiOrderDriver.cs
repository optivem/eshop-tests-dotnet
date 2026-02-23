using Commons.Util;
using Optivem.EShop.SystemTest.Infra.Shop.Client.Api;
using Optivem.EShop.SystemTest.Core.Shop.Driver.Dtos.Orders;
using Optivem.EShop.SystemTest.Core.Shop.Driver.Dtos.Error;
using Optivem.EShop.SystemTest.Core.Shop.Driver;
using Optivem.EShop.SystemTest.Infra.Shop.Client.Api.Dtos.Errors;

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
            .MapErrorAsync(MapError);

    public Task<Result<VoidValue, SystemError>> CancelOrderAsync(string? orderNumber)
        => _apiClient.Orders().CancelOrderAsync(orderNumber)
            .MapErrorAsync(MapError);

    public Task<Result<ViewOrderResponse, SystemError>> ViewOrderAsync(string? orderNumber)
        => _apiClient.Orders().ViewOrderAsync(orderNumber)
            .MapErrorAsync(MapError);

    private static SystemError MapError(ProblemDetailResponse problemDetail)
    {
        var message = problemDetail.Detail ?? "Request failed";
        if (problemDetail.Errors != null && problemDetail.Errors.Any())
        {
            var fieldErrors = problemDetail.Errors
                .Select(e => new SystemError.FieldError(e.Field ?? "unknown", e.Message ?? string.Empty, e.Code))
                .ToList();
            return SystemError.Of(message, fieldErrors.AsReadOnly());
        }
        return SystemError.Of(message);
    }
}