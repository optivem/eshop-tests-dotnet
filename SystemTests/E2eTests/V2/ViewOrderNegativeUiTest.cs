using Driver.Adapter.Shop.Ui.Client.Pages;
using SystemTests.E2eTests.V2.Base;
using SystemTests.TestInfrastructure.Base.V2;
using Shouldly;
using Xunit;

namespace SystemTests.E2eTests.V2;

public class ViewOrderNegativeUiTest : BaseE2eTest
{
    protected override Task SetShopClientAsync()
    {
        return SetUpShopUiClientAsync();
    }

    [Fact]
    public async Task ShouldNotBeAbleToViewNonExistentOrder()
    {
        var orderNumber = "NON-EXISTENT-ORDER-99999";
        var homePage = await _shopUiClient!.OpenHomePageAsync();
        var orderHistoryPage = await homePage.ClickOrderHistoryAsync();
        await orderHistoryPage.InputOrderNumberAsync(orderNumber);
        await orderHistoryPage.ClickSearchAsync();
        (await orderHistoryPage.WaitForOrderRowAsync(orderNumber, 3000)).ShouldBeFalse();
    }
}



