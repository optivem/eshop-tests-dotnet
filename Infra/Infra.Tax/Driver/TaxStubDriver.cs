using Commons.Util;
using Optivem.EShop.SystemTest.Core.Tax.Client;
using Optivem.EShop.SystemTest.Driver.Ports.Tax.Dtos;
using Optivem.EShop.SystemTest.Driver.Ports.Tax.Dtos.Error;
using Optivem.EShop.SystemTest.Infra.Tax.Client.Dtos;
using Optivem.EShop.SystemTest.Infra.Tax.Client.Dtos.Error;

namespace Optivem.EShop.SystemTest.Core.Tax.Driver;

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
