using Common;
using Driver.Port.Erp.Dtos;
using Driver.Port.Erp.Dtos.Error;

namespace Driver.Port.Erp;

public interface IErpDriver : IDisposable
{
    Task<Result<VoidValue, ErpErrorResponse>> GoToErpAsync();

    Task<Result<GetProductResponse, ErpErrorResponse>> GetProductAsync(GetProductRequest request);

    Task<Result<VoidValue, ErpErrorResponse>> ReturnsProductAsync(ReturnsProductRequest request);
}

