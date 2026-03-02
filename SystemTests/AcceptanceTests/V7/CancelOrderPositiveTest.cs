using SystemTests.AcceptanceTests.V7.Base;
using Dsl.Core.Shop;
using Driver.Port.Shop.Dtos;
using Optivem.Testing;

namespace SystemTests.AcceptanceTests.V7;

public class CancelOrderPositiveTest : BaseAcceptanceTest
{
    [Theory]
    [ChannelData(ChannelType.UI, ChannelType.API)]
    public async Task ShouldHaveCancelledStatusWhenCancelled(Channel channel)
    {
        await Scenario(channel)
            .Given().Order()
            .When().CancelOrder()
            .Then().ShouldSucceed()
            .And().Order()
            .HasStatus(OrderStatus.Cancelled);
    }
}



