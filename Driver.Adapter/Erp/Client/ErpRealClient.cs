using Common;
using Driver.Core.Erp.Client.Dtos;
using Driver.Core.Erp.Client.Dtos.Error;

namespace Driver.Core.Erp.Client;

public class ErpRealClient : BaseErpClient
{
    private const string ProductsEndpoint = "/api/products";

    public ErpRealClient(string baseUrl) : base(baseUrl)
    {
    }


    public Task<Result<VoidValue, ExtErpErrorResponse>> CreateProductAsync(ExtCreateProductRequest request)
        => HttpClient.PostAsync(ProductsEndpoint, request);
}

