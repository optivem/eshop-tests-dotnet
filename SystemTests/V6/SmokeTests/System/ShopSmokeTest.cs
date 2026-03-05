using SystemTests.TestInfrastructure.Base.V6;
using Dsl.Core.Shop;
using Optivem.Testing;
using Xunit;

namespace SystemTests.V6.SmokeTests.System;

public class ShopSmokeTest : BaseScenarioDslTest
{
    [Theory]
    [ChannelData(ChannelType.UI, ChannelType.API)]
    public async Task ShouldBeAbleToGoToShop(Channel channel)
    {
        await Scenario(channel)
            .When().GoToShop()
            .Then().ShouldSucceed();
    }
}











