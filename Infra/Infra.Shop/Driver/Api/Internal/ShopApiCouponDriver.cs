using Commons.Util;
using Optivem.EShop.SystemTest.Infra.Shop.Client.Api;
using Optivem.EShop.SystemTest.Core.Shop.Commons.Dtos.Coupons;
using Optivem.EShop.SystemTest.Core.Shop.Commons;
using Optivem.EShop.SystemTest.Core.Shop.Driver.Internal;
using Optivem.EShop.SystemTest.Core.Shop.Commons.Dtos.Errors;
using Optivem.EShop.SystemTest.Infra.Shop.Client.Api.Dtos.Errors;

namespace Optivem.EShop.SystemTest.Core.Shop.Driver.Api.Internal;

public class ShopApiCouponDriver : ICouponDriver
{
    private readonly ShopApiClient _apiClient;

    public ShopApiCouponDriver(ShopApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public Task<Result<VoidValue, SystemError>> PublishCouponAsync(PublishCouponRequest request)
        => _apiClient.Coupons().PublishCouponAsync(request)
            .MapErrorAsync(MapError);

    public Task<Result<BrowseCouponsResponse, SystemError>> BrowseCouponsAsync()
        => _apiClient.Coupons().BrowseCouponsAsync()
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