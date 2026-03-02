using Common;
using Driver.Api.Erp.Dtos;
using Driver.Api.Erp.Dtos.Error;
using Driver.Core.Erp.Client;
using Driver.Core.Erp.Client.Dtos;
using Driver.Core.Erp.Client.Dtos.Error;

namespace Driver.Core.Erp;

public class ErpRealDriver : BaseErpDriver<ErpRealClient>
{
    private const string DefaultTitle = "Test Product Title";
    private const string DefaultDescription = "Test Product Description";
    private const string DefaultCategory = "Test Category";
    private const string DefaultBrand = "Test Brand";

    public ErpRealDriver(string baseUrl) : base(new ErpRealClient(baseUrl))
    {
    }

    public override Task<Result<VoidValue, ErpErrorResponse>> ReturnsProductAsync(ReturnsProductRequest request)
    {
        var createProductRequest = new ExtCreateProductRequest
        {
            Id = request.Sku,
            Title = DefaultTitle,
            Description = DefaultDescription,
            Category = DefaultCategory,
            Brand = DefaultBrand,
            Price = request.Price
        };

        return _client.CreateProductAsync(createProductRequest)
            .MapErrorAsync(error => MapError(error));
    }
}

