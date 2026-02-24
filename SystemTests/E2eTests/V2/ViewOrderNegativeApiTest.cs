using Commons.Util;
using Optivem.EShop.SystemTest.E2eTests.V2.Base;
using Optivem.EShop.SystemTest.Driver.Api.Shop.Dtos.Error;
using Optivem.EShop.SystemTest.Base.V2;
using Shouldly;
using Xunit;

namespace Optivem.EShop.SystemTest.E2eTests.V2;

public class ViewOrderNegativeApiTest : BaseE2eTest
{
    protected override Task SetShopClientAsync()
    {
        SetUpShopApiClient();
        return Task.CompletedTask;
    }

    [Fact]
    public async Task ShouldNotBeAbleToViewNonExistentOrder()
    {
        var orderNumber = "NON-EXISTENT-ORDER-99999";
        var result = await _shopApiClient!.Orders().ViewOrderAsync(orderNumber);
        result.ShouldBeFailure();
        result.Error.Detail.ShouldBe("Order NON-EXISTENT-ORDER-99999 does not exist.");
    }
}
