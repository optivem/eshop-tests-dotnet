using Commons.Util;
using Driver.Impl.Commons.Http;
using Optivem.EShop.SystemTest.Infra.Shop.Client.Api.Dtos.Errors;

namespace Optivem.EShop.SystemTest.Infra.Shop.Client.Api.Controllers;

public class HealthController
{
    private const string Endpoint = "/health";

    private readonly JsonHttpClient<ProblemDetailResponse> _httpClient;

    public HealthController(JsonHttpClient<ProblemDetailResponse> httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<Result<VoidValue, ProblemDetailResponse>> CheckHealthAsync()
        => _httpClient.GetAsync(Endpoint);
}
