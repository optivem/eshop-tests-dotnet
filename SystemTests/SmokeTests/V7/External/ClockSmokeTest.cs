using Common;
using SystemTests.TestInfrastructure.Base.V5;
using Shouldly;
using Xunit;

namespace SystemTests.SmokeTests.V7.External;

public class ClockSmokeTest : BaseSystemDslTest
{
    [Fact]
    public async Task ShouldBeAbleToGoToClock()
    {
        (await _app.Clock().GoToClock()
            .Execute())
            .ShouldSucceed();
    }
}


