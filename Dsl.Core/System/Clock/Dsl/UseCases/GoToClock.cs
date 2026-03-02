using Dsl.Core.Clock.Dsl.UseCases.Base;
using Driver.Port.Clock;
using Driver.Port.Clock.Dtos;
using Common;
using Dsl.Common;

namespace Dsl.Core.Clock.Dsl.UseCases;

public class GoToClock : BaseClockCommand<VoidValue, VoidVerification>
{
    public GoToClock(IClockDriver driver, UseCaseContext context)
        : base(driver, context)
    {
    }

    public override async Task<ClockUseCaseResult<VoidValue, VoidVerification>> Execute()
    {
        var result = await _driver.GoToClockAsync();

        return new ClockUseCaseResult<VoidValue, VoidVerification>(
            result,
            _context,
            (response, ctx) => new VoidVerification(response, ctx));
    }
}



