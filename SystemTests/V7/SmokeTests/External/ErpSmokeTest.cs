using SystemTests.TestInfrastructure.Base.V7;
using Xunit;

namespace SystemTests.V7.SmokeTests.External;

public class ErpSmokeTest : BaseScenarioDslTest
{
    [Fact]
    public async Task ShouldBeAbleToGoToErp()
    {
        await Scenario().Assume().Erp().ShouldBeRunning();
    }
}










