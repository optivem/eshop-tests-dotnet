using Optivem.EShop.SystemTest.Driver.Ports.Clock;
using Optivem.EShop.SystemTest.Driver.Ports.Clock.Dtos;
using Driver.Shared.Dsl;

namespace Optivem.EShop.SystemTest.Core.Clock.Dsl.UseCases.Base;

public abstract class BaseClockCommand<TResponse, TVerification>
    where TVerification : ResponseVerification<TResponse>
{
    protected readonly IClockDriver _driver;
    protected readonly UseCaseContext _context;

    protected BaseClockCommand(IClockDriver driver, UseCaseContext context)
    {
        _driver = driver;
        _context = context;
    }

    public abstract Task<ClockUseCaseResult<TResponse, TVerification>> Execute();
}
