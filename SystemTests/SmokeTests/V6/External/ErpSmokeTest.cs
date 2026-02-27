using Common;
using SystemTests.TestInfrastructure.Base.V5;
using Shouldly;
using Xunit;

namespace SystemTests.SmokeTests.V6.External;

public class ErpSmokeTest : BaseSystemDslTest
{
    [Fact]
    public async Task ShouldBeAbleToGoToErp()
    {
        (await _app.Erp().GoToErp()
            .Execute())
            .ShouldSucceed();
    }
}


