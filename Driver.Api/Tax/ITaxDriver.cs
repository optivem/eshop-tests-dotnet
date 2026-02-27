using Common;
using D;
using D;

namespace Driver.Api.Tax;

public interface ITaxDriver : IDisposable
{
    Task<Result<VoidValue, TaxErrorResponse>> GoToTaxAsync();
    Task<Result<GetTaxResponse, TaxErrorResponse>> GetTaxRateAsync(string? country);
    Task<Result<VoidValue, TaxErrorResponse>> ReturnsTaxRateAsync(ReturnsTaxRateRequest request);
}
