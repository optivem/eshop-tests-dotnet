using SystemTests.V7.AcceptanceTests.Base;
using Dsl.Core.Shop;
using Optivem.Testing;

namespace SystemTests.V7.AcceptanceTests;

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











