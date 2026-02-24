using Optivem.EShop.SystemTest.Dsl.Clock.Dsl.UseCases.Base;
using Optivem.EShop.SystemTest.Driver.Api.Clock;
using Optivem.EShop.SystemTest.Driver.Api.Clock.Dtos;
using Commons.Util;
using Driver.Core.Driver.Commons.Dsl;

namespace Optivem.EShop.SystemTest.Dsl.Clock.Dsl.UseCases;

public class ReturnsTime : BaseClockCommand<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>
{
    private string? _time;

    public ReturnsTime(IClockDriver driver, Driver.Core.Driver.Commons.Dsl.UseCaseContext context)
        : base(driver, context)
    {
    }

    public ReturnsTime Time(string? time)
    {
        _time = time;
        return this;
    }

    public override async Task<ClockDriver.Core.Driver.Commons.Dsl.UseCaseResult<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>> Execute()
    {
        var request = new ReturnsTimeRequest
        {
            Time = _time
        };

        var result = await _driver.ReturnsTimeAsync(request);

        return new ClockDriver.Core.Driver.Commons.Dsl.UseCaseResult<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>(
            result,
            _context,
            (response, ctx) => new Driver.Core.Driver.Commons.Dsl.VoidVerification(response, ctx));
    }
}
