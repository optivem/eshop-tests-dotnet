using SystemTests.TestInfrastructure.Base.V7;
using Optivem.Testing;
using Xunit;

namespace SystemTests.V7.SmokeTests.System;

public class ShopSmokeTest : BaseScenarioDslTest
{
    [Theory]
    [ChannelData(ChannelType.UI, ChannelType.API)]
    public async Task ShouldBeAbleToGoToShop(Channel channel)
    {
        await Scenario(channel).Assume().Shop().ShouldBeRunning();
    }
}











