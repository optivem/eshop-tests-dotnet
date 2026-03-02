using Common;
using Driver.Core.Tax.Client;
using Driver.Api.Tax.Dtos;
using Driver.Api.Tax.Dtos.Error;

namespace Driver.Core.Tax;

public class TaxRealDriver : BaseTaxDriver<TaxRealClient>
{
    public TaxRealDriver(string baseUrl) : base(new TaxRealClient(baseUrl))
    {
    }

    public override Task<Result<VoidValue, TaxErrorResponse>> ReturnsTaxRateAsync(ReturnsTaxRateRequest request)
    {
        // No-op for real driver - data already exists in real service
        return Task.FromResult(Result.Success<TaxErrorResponse>());
    }
}

