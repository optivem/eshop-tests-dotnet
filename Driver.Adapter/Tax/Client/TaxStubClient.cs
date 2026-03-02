using Common;
using Driver.Common.Client.WireMock;
using Driver.Common.Client.Http;
using Driver.Adapter.Tax.Client.Dtos;
using Driver.Adapter.Tax.Client.Dtos.Error;

namespace Driver.Adapter.Tax.Client;

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


