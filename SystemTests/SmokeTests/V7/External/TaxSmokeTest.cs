using SystemTests.TestInfrastructure.Base.V7;
using Xunit;

namespace SystemTests.SmokeTests.V7.External;

public class TaxSmokeTest : BaseScenarioDslTest
{
    [Fact]
    public async Task ShouldBeAbleToGoToTax()
    {
        await Background().Tax().ShouldBeRunning();
    }
}


