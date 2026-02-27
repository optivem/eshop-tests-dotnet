using Common;
using SystemTests.TestInfrastructure.Base.V5;
using Driver.Core.Shop;
using Optivem.Testing;
using Shouldly;
using Xunit;

namespace SystemTests.SmokeTests.V5.System;

public class ShopSmokeTest : BaseSystemDslTest
{
    [Theory]
    [ChannelData(ChannelType.UI, ChannelType.API)]
    public async Task ShouldBeAbleToGoToShop(Channel channel)
    {
        (await (await _app.Shop(channel)).GoToShop()
            .Execute())
            .ShouldSucceed();
    }
}



