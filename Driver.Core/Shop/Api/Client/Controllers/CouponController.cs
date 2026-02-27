using Driver.Shared.Http;
using Common;
using Optivem.EShop.SystemTest.Driver.Shop.Client.Api.Dtos.Errors;
using D;

namespace Optivem.EShop.SystemTest.Driver.Shop.Client.Api.Controllers;

public class CouponController
{
    private const string Endpoint = "/api/coupons";

    private readonly JsonHttpClient<ProblemDetailResponse> _httpClient;

    public CouponController(JsonHttpClient<ProblemDetailResponse> httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<Result<VoidValue, ProblemDetailResponse>> PublishCouponAsync(PublishCouponRequest request)
        => _httpClient.PostAsync(Endpoint, request);

    public Task<Result<BrowseCouponsResponse, ProblemDetailResponse>> BrowseCouponsAsync()
        => _httpClient.GetAsync<BrowseCouponsResponse>(Endpoint);
}
