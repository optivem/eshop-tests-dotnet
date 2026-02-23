using Commons.Util;
using Commons.Http;
using Optivem.EShop.SystemTest.Infra.Shop.Client.Api.Dtos.Errors;
using Optivem.EShop.SystemTest.Infra.Shop.Client.Api;
using Optivem.EShop.SystemTest.Core.Shop.Commons.Dtos.Errors;
using Optivem.EShop.SystemTest.Core.Shop.Driver.Internal;
using Optivem.EShop.SystemTest.Core.Shop.Driver.Api.Internal;

namespace Optivem.EShop.SystemTest.Core.Shop.Driver.Api;

public class ShopApiDriver : IShopDriver
{
    private readonly ShopApiClient _apiClient;
    private readonly IOrderDriver _orderDriver;
    private readonly ICouponDriver _couponDriver;

    public ShopApiDriver(string baseUrl)
    {
        _apiClient = new ShopApiClient(baseUrl);
        _orderDriver = new ShopApiOrderDriver(_apiClient);
        _couponDriver = new ShopApiCouponDriver(_apiClient);
    }

    public ValueTask DisposeAsync()
    {
        _apiClient?.Dispose();
        return ValueTask.CompletedTask;
    }

    public Task<Result<VoidValue, SystemError>> GoToShopAsync()
        => _apiClient.Health().CheckHealthAsync()
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

    public IOrderDriver Orders() => _orderDriver;

    public ICouponDriver Coupons() => _couponDriver;
}
