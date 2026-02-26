using Common;
using Optivem.EShop.SystemTest.Base.V3;
using Shouldly;
using Xunit;

namespace Optivem.EShop.SystemTest.SmokeTests.V3.External;

public class ErpSmokeTest : BaseDriverTest
{
    public override Task InitializeAsync()
    {
        SetUpExternalDrivers();
        return Task.CompletedTask;
    }

    [Fact]
    public async Task ShouldBeAbleToGoToErp()
    {
        var result = await _erpDriver!.GoToErpAsync();
        result.ShouldBeSuccess();
    }
}
