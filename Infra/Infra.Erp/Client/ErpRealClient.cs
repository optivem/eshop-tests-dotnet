using Commons.Util;
using Optivem.EShop.SystemTest.Infra.Erp.Client.Dtos;
using Optivem.EShop.SystemTest.Infra.Erp.Client.Dtos.Error;

namespace Optivem.EShop.SystemTest.Infra.Erp.Client;

public class ErpRealClient : BaseErpClient
{
    private const string ProductsEndpoint = "/api/products";

    public ErpRealClient(string baseUrl) : base(baseUrl)
    {
    }


    public Task<Result<VoidValue, ExtErpErrorResponse>> CreateProductAsync(ExtCreateProductRequest request)
        => HttpClient.PostAsync(ProductsEndpoint, request);
}
