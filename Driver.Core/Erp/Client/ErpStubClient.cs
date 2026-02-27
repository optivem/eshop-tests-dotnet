using Common;
using D;
using D;
using Optivem.EShop.SystemTest.Driver.Erp.Client.Dtos;
using Optivem.EShop.SystemTest.Driver.Erp.Client.Dtos.Error;

namespace Optivem.EShop.SystemTest.Driver.Erp.Client;

public class ErpStubClient : BaseErpClient
{
    private const string ErpProductsEndpoint = "/erp/api/products";

    private readonly JsonWireMockClient _wireMockClient;

    public ErpStubClient(string baseUrl) : base(baseUrl)
    {
        _wireMockClient = new JsonWireMockClient(baseUrl);
    }

    public new void Dispose()
    {
        base.Dispose();
        _wireMockClient?.Dispose();
    }

    public Task<Result<VoidValue, ExtErpErrorResponse>> ConfigureGetProductAsync(ExtProductDetailsResponse response)
        => _wireMockClient.StubGetAsync($"{ErpProductsEndpoint}/{response.Id}", HttpStatus.Ok, response)
            .MapErrorAsync(ExtErpErrorResponse.From);

}
