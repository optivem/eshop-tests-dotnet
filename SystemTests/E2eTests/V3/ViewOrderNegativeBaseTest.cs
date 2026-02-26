using Common.Util;
using Optivem.EShop.SystemTest.E2eTests.V3.Base;
using Shouldly;
using Xunit;

namespace Optivem.EShop.SystemTest.E2eTests.V3;

public abstract class ViewOrderNegativeBaseTest : BaseE2eTest
{
    [Fact]
    public async Task ShouldNotBeAbleToViewNonExistentOrder()
    {
        var orderNumber = "NON-EXISTENT-ORDER-99999";
        var result = await _shopDriver!.ViewOrderAsync(orderNumber);
        result.ShouldBeFailure();
        result.Error.Message.ShouldBe("Order NON-EXISTENT-ORDER-99999 does not exist.");
    }
}

