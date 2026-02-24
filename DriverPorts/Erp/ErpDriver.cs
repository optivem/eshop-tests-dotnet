using Commons.Util;
using Optivem.EShop.SystemTest.Driver.Ports.Erp.Dtos;
using Optivem.EShop.SystemTest.Driver.Ports.Erp.Dtos.Error;

namespace Optivem.EShop.SystemTest.Driver.Ports.Erp;

public interface IErpDriver : IDisposable
{
    Task<Result<VoidValue, ErpErrorResponse>> GoToErpAsync();

    Task<Result<GetProductResponse, ErpErrorResponse>> GetProductAsync(GetProductRequest request);

    Task<Result<VoidValue, ErpErrorResponse>> ReturnsProductAsync(ReturnsProductRequest request);
}
