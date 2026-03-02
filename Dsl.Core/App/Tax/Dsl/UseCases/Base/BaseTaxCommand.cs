using Driver.Port.Tax;
using Driver.Port.Tax.Dtos.Error;
using Dsl.Common;

namespace Dsl.Core.Tax.Dsl.UseCases.Base;

public abstract class BaseTaxCommand<TResponse, TVerification>
    where TVerification : ResponseVerification<TResponse>
{
    protected readonly ITaxDriver _driver;
    protected readonly UseCaseContext _context;

    protected BaseTaxCommand(ITaxDriver driver, UseCaseContext context)
    {
        _driver = driver;
        _context = context;
    }

    public abstract Task<TaxUseCaseResult<TResponse, TVerification>> Execute();
}



