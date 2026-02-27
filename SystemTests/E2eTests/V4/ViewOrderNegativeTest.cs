using Common;
using Driver.Core.Shop;
using SystemTests.E2eTests.V4.Base;
using Optivem.Testing;
using Shouldly;
using Xunit;

namespace SystemTests.E2eTests.V4;

public class ViewOrderNegativeTest : BaseE2eTest
{
    public static IEnumerable<object[]> NonExistentOrderValues()
    {
        yield return new object[] { "NON-EXISTENT-ORDER-99999", "Order NON-EXISTENT-ORDER-99999 does not exist." };
        yield return new object[] { "NON-EXISTENT-ORDER-88888", "Order NON-EXISTENT-ORDER-88888 does not exist." };
        yield return new object[] { "NON-EXISTENT-ORDER-77777", "Order NON-EXISTENT-ORDER-77777 does not exist." };
    }

    [Theory]
    [ChannelData(ChannelType.UI, ChannelType.API)]
    [ChannelMemberData(nameof(NonExistentOrderValues))]
    public async Task ShouldNotBeAbleToViewNonExistentOrder(Channel channel, string orderNumber, string expectedErrorMessage)
    {
        await SetChannelAsync(channel);

        var result = await _shopDriver!.ViewOrderAsync(orderNumber);

        result.ShouldBeFailure();
        result.Error.Message.ShouldBe(expectedErrorMessage);
    }
}



