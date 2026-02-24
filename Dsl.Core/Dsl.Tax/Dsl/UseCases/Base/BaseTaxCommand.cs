using Optivem.EShop.SystemTest.Driver.Api.Tax;
using Optivem.EShop.SystemTest.Driver.Api.Tax.Dtos.Error;
using Driver.Core.Driver.Commons.Dsl;

namespace Optivem.EShop.SystemTest.Dsl.Tax.Dsl.UseCases.Base;

public abstract class BaseTaxCommand<TResponse, TVerification>
    where TVerification : Driver.Core.Driver.Commons.Dsl.ResponseVerification<TResponse>
{
    protected readonly ITaxDriver _driver;
    protected readonly Driver.Core.Driver.Commons.Dsl.UseCaseContext _context;

    protected BaseTaxCommand(ITaxDriver driver, Driver.Core.Driver.Commons.Dsl.UseCaseContext context)
    {
        _driver = driver;
        _context = context;
    }

    public abstract Task<TaxDriver.Core.Driver.Commons.Dsl.UseCaseResult<TResponse, TVerification>> Execute();
}
