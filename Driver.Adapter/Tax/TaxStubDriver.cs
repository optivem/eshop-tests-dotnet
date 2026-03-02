using Common;
using Driver.Adapter.Tax.Client;
using Driver.Port.Tax.Dtos;
using Driver.Port.Tax.Dtos.Error;
using Driver.Adapter.Tax.Client.Dtos;
using Driver.Adapter.Tax.Client.Dtos.Error;

namespace Driver.Adapter.Tax;

public class TaxStubDriver : BaseTaxDriver<TaxStubClient>
{
    public TaxStubDriver(string baseUrl) : base(new TaxStubClient(baseUrl))
    {
    }

    public override Task<Result<VoidValue, TaxErrorResponse>> ReturnsTaxRateAsync(ReturnsTaxRateRequest request)
    {
        var country = request.Country!;
        var taxRate = Converter.ToDecimal(request.TaxRate)!.Value;

        var response = new ExtCountryDetailsResponse
        {
            Id = country,
            TaxRate = taxRate,
            CountryName = country
        };

        return _client.ConfigureGetCountryAsync(response)
            .MapErrorAsync(MapError);
    }
}

