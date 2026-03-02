using Common;
using Driver.Api.Erp.Dtos;
using Driver.Api.Erp.Dtos.Error;

namespace Driver.Api.Erp;

public interface IErpDriver : IDisposable
{
    Task<Result<VoidValue, ErpErrorResponse>> GoToErpAsync();

    Task<Result<GetProductResponse, ErpErrorResponse>> GetProductAsync(GetProductRequest request);

    Task<Result<VoidValue, ErpErrorResponse>> ReturnsProductAsync(ReturnsProductRequest request);
}

