using SystemTests.TestInfrastructure.Base.V7;
using Xunit;

namespace SystemTests.V7.SmokeTests.External;

public class TaxSmokeTest : BaseScenarioDslTest
{
    [Fact]
    public async Task ShouldBeAbleToGoToTax()
    {
        await Scenario().Assume().Tax().ShouldBeRunning();
    }
}










