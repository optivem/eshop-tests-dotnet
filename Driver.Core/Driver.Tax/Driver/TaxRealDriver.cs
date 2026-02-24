using Commons.Util;
using Optivem.EShop.SystemTest.Dsl.Tax.Client;
using Optivem.EShop.SystemTest.Driver.Api.Tax.Dtos;
using Optivem.EShop.SystemTest.Driver.Api.Tax.Dtos.Error;

namespace Optivem.EShop.SystemTest.Dsl.Tax.Driver;

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
