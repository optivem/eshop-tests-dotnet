using Optivem.EShop.SystemTest.Core.Clock.Dsl.UseCases.Base;
using Optivem.EShop.SystemTest.Driver.Ports.Clock;
using Optivem.EShop.SystemTest.Driver.Ports.Clock.Dtos;
using Driver.Impl.Commons.Dsl;

namespace Optivem.EShop.SystemTest.Core.Clock.Dsl.UseCases;

public class GetTime : BaseClockCommand<GetTimeResponse, GetTimeVerification>
{
    public GetTime(IClockDriver driver, UseCaseContext context)
        : base(driver, context)
    {
    }

    public override async Task<ClockUseCaseResult<GetTimeResponse, GetTimeVerification>> Execute()
    {
        var result = await _driver.GetTimeAsync();

        return new ClockUseCaseResult<GetTimeResponse, GetTimeVerification>(
            result,
            _context,
            (response, ctx) => new GetTimeVerification(response, ctx));
    }
}
