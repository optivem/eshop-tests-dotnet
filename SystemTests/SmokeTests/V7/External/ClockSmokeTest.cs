using SystemTests.TestInfrastructure.Base.V7;
using Xunit;

namespace SystemTests.SmokeTests.V7.External;

public class ClockSmokeTest : BaseScenarioDslTest
{
    [Fact]
    public async Task ShouldBeAbleToGoToClock()
    {
        await Scenario().Assume().Clock().ShouldBeRunning();
    }
}


