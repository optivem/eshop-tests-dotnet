using Commons.Util;
using Optivem.EShop.SystemTest.Core.Erp.Client;
using Optivem.EShop.SystemTest.Core.Erp.Driver.Dtos;
using Optivem.EShop.SystemTest.Core.Erp.Driver.Dtos.Error;

namespace Optivem.EShop.SystemTest.Core.Erp.Driver;

public abstract class BaseErpDriver<TClient> : IErpDriver
    where TClient : BaseErpClient
{
    protected readonly TClient _client;
    private bool _disposed;

    protected BaseErpDriver(TClient client)
    {
        _client = client;
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
            _client?.Dispose();
        _disposed = true;
    }

    public virtual Task<Result<VoidValue, ErpErrorResponse>> GoToErpAsync()
        => _client.CheckHealthAsync()
            .MapErrorAsync(ErpErrorResponse.From);

    public virtual Task<Result<GetProductResponse, ErpErrorResponse>> GetProductAsync(GetProductRequest request)
        => _client.GetProductAsync(request.Sku)
            .MapAsync(productDetails => new GetProductResponse
            {
                Sku = productDetails.Id,
                Price = productDetails.Price
            })
            .MapErrorAsync(ErpErrorResponse.From);

    public abstract Task<Result<VoidValue, ErpErrorResponse>> ReturnsProductAsync(ReturnsProductRequest request);
}