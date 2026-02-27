using Common;
using SystemTests.TestInfrastructure.Base.V5;
using Shouldly;
using Xunit;

namespace Optivem.EShop.SystemTest.SmokeTests.V5.External;

public class TaxSmokeTest : BaseSystemDslTest
{
    [Fact]
    public async Task ShouldBeAbleToGoToTax()
    {
        (await _app.Tax().GoToTax()
            .Execute())
            .ShouldSucceed();
    }
}

