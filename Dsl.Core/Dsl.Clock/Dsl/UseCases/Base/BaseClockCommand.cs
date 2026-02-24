using Optivem.EShop.SystemTest.Driver.Api.Clock;
using Optivem.EShop.SystemTest.Driver.Api.Clock.Dtos;
using Driver.Core.Driver.Commons.Dsl;

namespace Optivem.EShop.SystemTest.Dsl.Clock.Dsl.UseCases.Base;

public abstract class BaseClockCommand<TResponse, TVerification>
    where TVerification : Driver.Core.Driver.Commons.Dsl.ResponseVerification<TResponse>
{
    protected readonly IClockDriver _driver;
    protected readonly Driver.Core.Driver.Commons.Dsl.UseCaseContext _context;

    protected BaseClockCommand(IClockDriver driver, Driver.Core.Driver.Commons.Dsl.UseCaseContext context)
    {
        _driver = driver;
        _context = context;
    }

    public abstract Task<ClockDriver.Core.Driver.Commons.Dsl.UseCaseResult<TResponse, TVerification>> Execute();
}
