using Common;
using SystemTests.TestInfrastructure.Base.V3;
using Shouldly;
using Xunit;

namespace SystemTests.V3.SmokeTests.System;

public abstract class ShopBaseSmokeTest : BaseDriverTest
{
    protected abstract Task SetUpShopDriverAsync();

    public override async Task InitializeAsync()
    {
        await SetUpShopDriverAsync();
    }

    [Fact]
    public async Task ShouldBeAbleToGoToShop()
    {
        var result = await _shopDriver!.GoToShopAsync();
        result.ShouldBeSuccess();
    }
}










