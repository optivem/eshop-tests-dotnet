using SystemTests.TestInfrastructure.Base.V7;
using Xunit;

namespace SystemTests.SmokeTests.V7.External;

public class ErpSmokeTest : BaseScenarioDslTest
{
    [Fact]
    public async Task ShouldBeAbleToGoToErp()
    {
        await Background().Erp().ShouldBeRunning();
    }
}


