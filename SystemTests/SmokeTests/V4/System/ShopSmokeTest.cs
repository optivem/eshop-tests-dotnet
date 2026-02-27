using Common;
using SystemTests.TestInfrastructure.Base.V4;
using Driver.Core.Shop;
using Optivem.Testing;
using Shouldly;
using Xunit;

namespace Optivem.EShop.SystemTest.SmokeTests.V4.System;

public class ShopSmokeTest : BaseChannelDriverTest
{
    [Theory]
    [ChannelData(ChannelType.UI, ChannelType.API)]
    public async Task ShouldBeAbleToGoToShop(Channel channel)
    {
        await SetChannelAsync(channel);

        var result = await _shopDriver!.GoToShopAsync();
        result.ShouldBeSuccess();
    }
}


