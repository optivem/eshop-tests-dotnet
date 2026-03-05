using Common;
using SystemTests.TestInfrastructure.Base.V2;
using Xunit;

namespace SystemTests.V2.SmokeTests.External;

public class ErpSmokeTest : BaseClientTest
{
    public override Task InitializeAsync()
    {
        SetUpExternalClients();
        return Task.CompletedTask;
    }

    [Fact]
    public async Task ShouldBeAbleToGoToErp()
    {
        var result = await _erpClient!.CheckHealthAsync();
        result.ShouldBeSuccess();
    }
}











