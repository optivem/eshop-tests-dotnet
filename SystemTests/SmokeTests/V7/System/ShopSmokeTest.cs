using SystemTests.TestInfrastructure.Base.V7;
using Optivem.Testing;
using Xunit;

namespace SystemTests.SmokeTests.V7.System;

public class ShopSmokeTest : BaseScenarioDslTest
{
    [Theory]
    [ChannelData(ChannelType.UI, ChannelType.API)]
    public async Task ShouldBeAbleToGoToShop(Channel channel)
    {
        await Background(channel).Shop().ShouldBeRunning();
    }
}



