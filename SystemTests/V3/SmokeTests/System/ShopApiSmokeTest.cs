namespace SystemTests.V3.SmokeTests.System;

public class ShopApiSmokeTest : ShopBaseSmokeTest
{
    protected override Task SetUpShopDriverAsync()
    {
        SetUpShopApiDriver();
        return Task.CompletedTask;
    }
}









