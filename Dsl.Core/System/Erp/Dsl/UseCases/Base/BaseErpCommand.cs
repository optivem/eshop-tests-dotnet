using Driver.Api.Erp;
using Driver.Api.Erp.Dtos.Error;
using Dsl.Common;

namespace Driver.Core.Erp.Dsl.UseCases.Base;

public abstract class BaseErpCommand<TResponse, TVerification>
    where TVerification : ResponseVerification<TResponse>
{
    protected readonly IErpDriver _driver;
    protected readonly UseCaseContext _context;

    protected BaseErpCommand(IErpDriver driver, UseCaseContext context)
    {
        _driver = driver;
        _context = context;
    }

    public abstract Task<ErpUseCaseResult<TResponse, TVerification>> Execute();
}


