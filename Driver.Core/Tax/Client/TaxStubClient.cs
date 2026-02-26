using Common.Util;
using Driver.Shared.WireMock;
using Driver.Shared.Http;
using Optivem.EShop.SystemTest.Driver.Tax.Client.Dtos;
using Optivem.EShop.SystemTest.Driver.Tax.Client.Dtos.Error;

namespace Optivem.EShop.SystemTest.Core.Tax.Client;

public class TaxStubClient : BaseTaxClient
{
    private const string TaxCountriesEndpoint = "/tax/api/countries";

    private readonly JsonWireMockClient _wireMockClient;

    public TaxStubClient(string baseUrl) : base(baseUrl)
    {
        _wireMockClient = new JsonWireMockClient(baseUrl);
    }

    public Task<Result<VoidValue, ExtTaxErrorResponse>> ConfigureGetCountryAsync(ExtCountryDetailsResponse response)
        => _wireMockClient.StubGetAsync($"{TaxCountriesEndpoint}/{response.Id}", HttpStatus.Ok, response)
            .MapErrorAsync(ExtTaxErrorResponse.From);
}
