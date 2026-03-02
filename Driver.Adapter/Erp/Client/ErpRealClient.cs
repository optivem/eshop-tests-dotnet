using Common;
using Driver.Adapter.Erp.Client.Dtos;
using Driver.Adapter.Erp.Client.Dtos.Error;

namespace Driver.Adapter.Erp.Client;

public class ErpRealClient : BaseErpClient
{
    private const string ProductsEndpoint = "/api/products";

    public ErpRealClient(string baseUrl) : base(baseUrl)
    {
    }


    public Task<Result<VoidValue, ExtErpErrorResponse>> CreateProductAsync(ExtCreateProductRequest request)
        => HttpClient.PostAsync(ProductsEndpoint, request);
}

