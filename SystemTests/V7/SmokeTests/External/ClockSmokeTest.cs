using SystemTests.TestInfrastructure.Base.V7;
using Xunit;

namespace SystemTests.V7.SmokeTests.External;

public class ClockSmokeTest : BaseScenarioDslTest
{
    [Fact]
    public async Task ShouldBeAbleToGoToClock()
    {
        await Scenario().Assume().Clock().ShouldBeRunning();
    }
}










