using SystemTests.TestInfrastructure.Base.V6;
using Driver.Core.Shop;
using Optivem.Testing;
using Xunit;

namespace Optivem.EShop.SystemTest.SmokeTests.V6.System;

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


