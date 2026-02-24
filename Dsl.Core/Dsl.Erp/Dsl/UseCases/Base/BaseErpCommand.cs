using Optivem.EShop.SystemTest.Driver.Api.Erp;
using Optivem.EShop.SystemTest.Driver.Api.Erp.Dtos.Error;
using Driver.Core.Driver.Commons.Dsl;

namespace Optivem.EShop.SystemTest.Dsl.Erp.Dsl.UseCases.Base;

public abstract class BaseErpCommand<TResponse, TVerification>
    where TVerification : Driver.Core.Driver.Commons.Dsl.ResponseVerification<TResponse>
{
    protected readonly IErpDriver _driver;
    protected readonly Driver.Core.Driver.Commons.Dsl.UseCaseContext _context;

    protected BaseErpCommand(IErpDriver driver, Driver.Core.Driver.Commons.Dsl.UseCaseContext context)
    {
        _driver = driver;
        _context = context;
    }

    public abstract Task<ErpDriver.Core.Driver.Commons.Dsl.UseCaseResult<TResponse, TVerification>> Execute();
}
