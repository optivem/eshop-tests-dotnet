using SystemTests.TestInfrastructure.Base.V2;
using Shouldly;
using Xunit;

namespace SystemTests.V2.SmokeTests.System;

public class ShopUiSmokeTest : BaseClientTest
{
    public override async Task InitializeAsync()
    {
        await SetUpShopUiClientAsync();
    }

    [Fact]
    public async Task ShouldBeAbleToGoToShop()
    {
        await _shopUiClient!.OpenHomePageAsync();
        (await _shopUiClient.IsPageLoadedAsync()).ShouldBeTrue();
    }
}










