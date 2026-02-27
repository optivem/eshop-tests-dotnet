using Common;
using Driver.Common.WireMock;
using Driver.Common.Http;
using Driver.Core.Tax.Client.Dtos;
using Driver.Core.Tax.Client.Dtos.Error;

namespace Driver.Core.Tax.Client;

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


