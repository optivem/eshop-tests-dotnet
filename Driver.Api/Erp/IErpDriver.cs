using Common;
using Optivem.EShop.SystemTest.Driver.Api.Erp.Dtos;
using Optivem.EShop.SystemTest.Driver.Api.Erp.Dtos.Error;

namespace Optivem.EShop.SystemTest.Driver.Api.Erp;

public interface IErpDriver : IDisposable
{
    Task<Result<VoidValue, ErpErrorResponse>> GoToErpAsync();

    Task<Result<GetProductResponse, ErpErrorResponse>> GetProductAsync(GetProductRequest request);

    Task<Result<VoidValue, ErpErrorResponse>> ReturnsProductAsync(ReturnsProductRequest request);
}
