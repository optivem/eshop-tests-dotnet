using SystemTests.AcceptanceTests.V7.Base;
using Dsl.Core.Shop;
using Optivem.Testing;

namespace SystemTests.AcceptanceTests.V7;

public class BrowseCouponsPositiveTest : BaseAcceptanceTest
{
    [Theory]
    [ChannelData(ChannelType.UI, ChannelType.API)]
    public async Task ShouldBeAbleToBrowseCoupons(Channel channel)
    {
        await Scenario(channel)
            .When().BrowseCoupons()
            .Then().ShouldSucceed();
    }
}


