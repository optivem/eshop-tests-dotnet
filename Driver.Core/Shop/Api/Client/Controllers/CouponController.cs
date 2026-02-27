using Driver.Common.Http;
using Common;
using Driver.Core.Shop.Client.Api.Dtos.Errors;
using Driver.Api.Shop.Dtos;

namespace Driver.Core.Shop.Client.Api.Controllers;

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



