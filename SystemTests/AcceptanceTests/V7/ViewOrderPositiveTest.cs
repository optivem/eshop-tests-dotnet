using SystemTests.AcceptanceTests.V7.Base;
using Dsl.Core.Shop;
using Optivem.Testing;

namespace SystemTests.AcceptanceTests.V7;

public class ViewOrderPositiveTest : BaseAcceptanceTest
{
    [Theory]
    [ChannelData(ChannelType.UI, ChannelType.API)]
    public async Task ShouldBeAbleToViewOrder(Channel channel)
    {
        await Scenario(channel)
            .Given().Order()
            .When().ViewOrder()
            .Then().ShouldSucceed();
    }
}


