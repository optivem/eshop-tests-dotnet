using Common;
using Driver.Api.Tax.Dtos;
using Driver.Api.Tax.Dtos.Error;

namespace Driver.Api.Tax;

public interface ITaxDriver : IDisposable
{
    Task<Result<VoidValue, TaxErrorResponse>> GoToTaxAsync();
    Task<Result<GetTaxResponse, TaxErrorResponse>> GetTaxRateAsync(string? country);
    Task<Result<VoidValue, TaxErrorResponse>> ReturnsTaxRateAsync(ReturnsTaxRateRequest request);
}

