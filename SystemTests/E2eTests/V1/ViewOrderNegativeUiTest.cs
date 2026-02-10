using Optivem.EShop.SystemTest.E2eTests.V1.Base;
using Shouldly;
using Xunit;

namespace Optivem.EShop.SystemTest.E2eTests.V1;

public class ViewOrderNegativeUiTest : BaseE2eTest
{
    protected override async Task SetShopRawAsync()
    {
        await SetUpShopBrowserAsync();
    }

    [Fact]
    public async Task ShouldNotBeAbleToViewNonExistentOrder()
    {
        const string orderNumber = "NON-EXISTENT-ORDER-99999";
        await shopUiPage!.GotoAsync(_configuration.ShopUiBaseUrl);
        await shopUiPage.Locator("a[href='/order-history']").ClickAsync();
        await shopUiPage.Locator("[aria-label='Order Number']").FillAsync(orderNumber);
        await shopUiPage.Locator("[aria-label='Refresh Order List']").ClickAsync();

        var rowSelector = $"xpath=//tr[contains(., '{orderNumber}')]";
        (await shopUiPage.Locator(rowSelector).IsVisibleAsync()).ShouldBeFalse();
    }
}
