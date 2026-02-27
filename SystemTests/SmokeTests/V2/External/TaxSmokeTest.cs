using Common;
using SystemTests.TestInfrastructure.Base.V2;
using Xunit;

namespace Optivem.EShop.SystemTest.SmokeTests.V2.External;

public class TaxSmokeTest : BaseClientTest
{
    public override Task InitializeAsync()
    {
        SetUpExternalClients();
        return Task.CompletedTask;
    }

    [Fact]
    public async Task ShouldBeAbleToGoToTax()
    {
        var result = await _taxClient!.CheckHealthAsync();
        result.ShouldBeSuccess();
    }
}

