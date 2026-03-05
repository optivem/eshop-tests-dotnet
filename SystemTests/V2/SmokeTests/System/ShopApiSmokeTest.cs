using Common;
using SystemTests.TestInfrastructure.Base.V2;
using Xunit;

namespace SystemTests.V2.SmokeTests.System;

public class ShopApiSmokeTest : BaseClientTest
{
    public override Task InitializeAsync()
    {
        SetUpShopApiClient();
        return Task.CompletedTask;
    }

    [Fact]
    public async Task ShouldBeAbleToGoToShop()
    {
        var result = await _shopApiClient!.Health().CheckHealthAsync();
        result.ShouldBeSuccess();
    }
}










