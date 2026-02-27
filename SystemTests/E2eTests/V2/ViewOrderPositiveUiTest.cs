using Common;
using Optivem.EShop.SystemTest.Driver.Erp.Client.Dtos;
using Optivem.EShop.SystemTest.Driver.Shop.Client.Ui.Pages;
using Optivem.EShop.SystemTest.Driver.Api.Shop.Dtos;
using Optivem.EShop.SystemTest.E2eTests.Commons.Constants;
using Optivem.EShop.SystemTest.E2eTests.V2.Base;
using Optivem.EShop.SystemTest.Base.V2;
using Shouldly;
using Xunit;

namespace Optivem.EShop.SystemTest.E2eTests.V2;

public class ViewOrderPositiveUiTest : BaseE2eTest
{
    protected override Task SetShopClientAsync()
    {
        return SetUpShopUiClientAsync();
    }

    [Fact]
    public async Task ShouldViewPlacedOrder()
    {
        var sku = CreateUniqueSku(Defaults.SKU);
        (await _erpClient!.CreateProductAsync(new ExtCreateProductRequest { Id = sku, Title = "Test", Description = "Test", Category = "Test", Brand = "Test", Price = "20.00" })).ShouldBeSuccess();

        var homePage = await _shopUiClient!.OpenHomePageAsync();
        var newOrderPage = await homePage.ClickNewOrderAsync();
        await newOrderPage.InputSkuAsync(sku);
        await newOrderPage.InputQuantityAsync("5");
        await newOrderPage.InputCountryAsync(Defaults.COUNTRY);
        await newOrderPage.ClickPlaceOrderAsync();

        var placeOrderResult = await newOrderPage.GetResultAsync();
        placeOrderResult.ShouldBeSuccess();

        var orderNumber = NewOrderPage.GetOrderNumber(placeOrderResult.Value!);

        var orderHistoryPage = await (await _shopUiClient.OpenHomePageAsync()).ClickOrderHistoryAsync();
        await orderHistoryPage.InputOrderNumberAsync(orderNumber);
        await orderHistoryPage.ClickSearchAsync();
        (await orderHistoryPage.WaitForOrderRowAsync(orderNumber)).ShouldBeTrue();

        var orderDetailsPage = await orderHistoryPage.ClickViewOrderDetailsAsync(orderNumber);
        (await orderDetailsPage.GetOrderNumberAsync()).ShouldBe(orderNumber);
        (await orderDetailsPage.GetSkuAsync()).ShouldBe(sku);
        (await orderDetailsPage.GetCountryAsync()).ShouldBe(Defaults.COUNTRY);
        (await orderDetailsPage.GetQuantityAsync()).ShouldBe(5);
        (await orderDetailsPage.GetUnitPriceAsync()).ShouldBe(20.00m);
        (await orderDetailsPage.GetSubtotalPriceAsync()).ShouldBe(100.00m);
        (await orderDetailsPage.GetStatusAsync()).ShouldBe(OrderStatus.Placed);
        (await orderDetailsPage.GetDiscountRateAsync()).ShouldBeGreaterThanOrEqualTo(0);
        (await orderDetailsPage.GetDiscountAmountAsync()).ShouldBeGreaterThanOrEqualTo(0);
        (await orderDetailsPage.GetTaxRateAsync()).ShouldBeGreaterThanOrEqualTo(0);
        (await orderDetailsPage.GetTaxAmountAsync()).ShouldBeGreaterThanOrEqualTo(0);
        (await orderDetailsPage.GetTotalPriceAsync()).ShouldBeGreaterThan(0);
    }
}

