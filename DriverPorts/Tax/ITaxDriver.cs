using Commons.Util;
using Optivem.EShop.SystemTest.Driver.Ports.Tax.Dtos;
using Optivem.EShop.SystemTest.Driver.Ports.Tax.Dtos.Error;

namespace Optivem.EShop.SystemTest.Driver.Ports.Tax;

public interface ITaxDriver : IDisposable
{
    Task<Result<VoidValue, TaxErrorResponse>> GoToTaxAsync();
    Task<Result<GetTaxResponse, TaxErrorResponse>> GetTaxRateAsync(string? country);
    Task<Result<VoidValue, TaxErrorResponse>> ReturnsTaxRateAsync(ReturnsTaxRateRequest request);
}
