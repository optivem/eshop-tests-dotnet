using Driver.Impl.Commons.Http;
using Commons.Util;
using Optivem.EShop.SystemTest.Infra.Erp.Client.Dtos;
using Optivem.EShop.SystemTest.Infra.Erp.Client.Dtos.Error;

namespace Optivem.EShop.SystemTest.Infra.Erp.Client;

public abstract class BaseErpClient : IDisposable
{
    private const string HealthEndpoint = "/health";
    private const string ProductsEndpoint = "/api/products";

    protected readonly JsonHttpClient<ExtErpErrorResponse> HttpClient;
    private bool _disposed;

    protected BaseErpClient(string baseUrl)
    {
        HttpClient = new JsonHttpClient<ExtErpErrorResponse>(baseUrl);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing)
            HttpClient?.Dispose();
        _disposed = true;
    }

    public Task<Result<VoidValue, ExtErpErrorResponse>> CheckHealthAsync()
        => HttpClient.GetAsync(HealthEndpoint);

    public Task<Result<ExtProductDetailsResponse, ExtErpErrorResponse>> GetProductAsync(string? sku)
        => HttpClient.GetAsync<ExtProductDetailsResponse>($"{ProductsEndpoint}/{sku}");
}
