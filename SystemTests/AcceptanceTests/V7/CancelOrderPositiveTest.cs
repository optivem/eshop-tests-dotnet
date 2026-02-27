using Optivem.EShop.SystemTest.AcceptanceTests.V7.Base;
using Optivem.EShop.SystemTest.Core.Shop;
using D;
using Optivem.Testing;

namespace Optivem.EShop.SystemTest.AcceptanceTests.V7;

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
