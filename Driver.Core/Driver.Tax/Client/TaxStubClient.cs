using Commons.Util;
using Driver.Core.Driver.Commons.WireMock;
using Driver.Core.Driver.Commons.Http;
using Optivem.EShop.SystemTest.Driver.Tax.Client.Dtos;
using Optivem.EShop.SystemTest.Driver.Tax.Client.Dtos.Error;

namespace Optivem.EShop.SystemTest.Driver.Tax.Client;

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
