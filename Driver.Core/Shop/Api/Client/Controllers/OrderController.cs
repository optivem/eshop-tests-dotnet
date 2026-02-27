using Common;
using Driver.Common.Http;
using Optivem.EShop.SystemTest.Driver.Shop.Client.Api.Dtos.Errors;
using Optivem.EShop.SystemTest.Driver.Api.Shop.Dtos;

namespace Optivem.EShop.SystemTest.Driver.Shop.Client.Api.Controllers;

public class OrderController
{
    private const string Endpoint = "/api/orders";

    private readonly JsonHttpClient<ProblemDetailResponse> _httpClient;

    public OrderController(JsonHttpClient<ProblemDetailResponse> httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<Result<PlaceOrderResponse, ProblemDetailResponse>> PlaceOrderAsync(PlaceOrderRequest request)
        => _httpClient.PostAsync<PlaceOrderResponse>(Endpoint, request);

    public Task<Result<ViewOrderResponse, ProblemDetailResponse>> ViewOrderAsync(string? orderNumber)
        => _httpClient.GetAsync<ViewOrderResponse>($"{Endpoint}/{orderNumber}");

    public Task<Result<VoidValue, ProblemDetailResponse>> CancelOrderAsync(string? orderNumber)
        => _httpClient.PostAsync($"{Endpoint}/{orderNumber}/cancel");
}


