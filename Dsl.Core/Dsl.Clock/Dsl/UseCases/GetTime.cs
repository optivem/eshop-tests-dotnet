using Optivem.EShop.SystemTest.Dsl.Clock.Dsl.UseCases.Base;
using Optivem.EShop.SystemTest.Driver.Api.Clock;
using Optivem.EShop.SystemTest.Driver.Api.Clock.Dtos;
using Driver.Core.Driver.Commons.Dsl;

namespace Optivem.EShop.SystemTest.Dsl.Clock.Dsl.UseCases;

public class GetTime : BaseClockCommand<GetTimeResponse, GetTimeVerification>
{
    public GetTime(IClockDriver driver, Driver.Core.Driver.Commons.Dsl.UseCaseContext context)
        : base(driver, context)
    {
    }

    public override async Task<ClockDriver.Core.Driver.Commons.Dsl.UseCaseResult<GetTimeResponse, GetTimeVerification>> Execute()
    {
        var result = await _driver.GetTimeAsync();

        return new ClockDriver.Core.Driver.Commons.Dsl.UseCaseResult<GetTimeResponse, GetTimeVerification>(
            result,
            _context,
            (response, ctx) => new GetTimeVerification(response, ctx));
    }
}
