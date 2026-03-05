namespace SystemTests.V3.SmokeTests.System;

public class ShopUiSmokeTest : ShopBaseSmokeTest
{
    protected override async Task SetUpShopDriverAsync()
    {
        await SetUpShopUiDriverAsync();
    }
}









