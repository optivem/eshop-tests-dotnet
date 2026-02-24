using Optivem.EShop.SystemTest.Dsl.Clock.Dsl.UseCases.Base;
using Optivem.EShop.SystemTest.Driver.Api.Clock;
using Optivem.EShop.SystemTest.Driver.Api.Clock.Dtos;
using Commons.Util;
using Driver.Core.Driver.Commons.Dsl;

namespace Optivem.EShop.SystemTest.Dsl.Clock.Dsl.UseCases;

public class GoToClock : BaseClockCommand<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>
{
    public GoToClock(IClockDriver driver, Driver.Core.Driver.Commons.Dsl.UseCaseContext context)
        : base(driver, context)
    {
    }

    public override async Task<ClockDriver.Core.Driver.Commons.Dsl.UseCaseResult<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>> Execute()
    {
        var result = await _driver.GoToClockAsync();

        return new ClockDriver.Core.Driver.Commons.Dsl.UseCaseResult<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>(
            result,
            _context,
            (response, ctx) => new Driver.Core.Driver.Commons.Dsl.VoidVerification(response, ctx));
    }
}
