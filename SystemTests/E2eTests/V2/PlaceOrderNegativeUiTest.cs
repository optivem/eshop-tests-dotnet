using Common;
using Driver.Core.Erp.Client.Dtos;
using Driver.Core.Shop.Client.Ui.Pages;
using Optivem.EShop.SystemTest.E2eTests.Commons.Constants;
using Optivem.EShop.SystemTest.E2eTests.V2.Base;
using Optivem.EShop.SystemTest.E2eTests.V4.Helpers;
using E2eTests.Providers;
using Optivem.EShop.SystemTest.Base.V2;
using Shouldly;
using Xunit;

namespace Optivem.EShop.SystemTest.E2eTests.V2;

public class PlaceOrderNegativeUiTest : BaseE2eTest
{
    protected override Task SetShopClientAsync()
    {
        return SetUpShopUiClientAsync();
    }

    [Fact]
    public async Task ShouldRejectOrderWithInvalidQuantity()
    {
        var homePage = await _shopUiClient!.OpenHomePageAsync();
        var newOrderPage = await homePage.ClickNewOrderAsync();
        await newOrderPage.InputSkuAsync(CreateUniqueSku(Defaults.SKU));
        await newOrderPage.InputQuantityAsync("invalid-quantity");
        await newOrderPage.InputCountryAsync(Defaults.COUNTRY);
        await newOrderPage.ClickPlaceOrderAsync();
        var result = await newOrderPage.GetResultAsync();
        result.ShouldBeFailure();
        result.Error.ShouldHaveMessageAndField("The request contains one or more validation errors", "quantity", "Quantity must be an integer");
    }

    [Fact]
    public async Task ShouldRejectOrderWithNonExistentSku()
    {
        var homePage = await _shopUiClient!.OpenHomePageAsync();
        var newOrderPage = await homePage.ClickNewOrderAsync();
        await newOrderPage.InputSkuAsync("NON-EXISTENT-SKU-12345");
        await newOrderPage.InputQuantityAsync(Defaults.QUANTITY);
        await newOrderPage.InputCountryAsync(Defaults.COUNTRY);
        await newOrderPage.ClickPlaceOrderAsync();
        var result = await newOrderPage.GetResultAsync();
        result.ShouldBeFailure();
        result.Error.ShouldHaveMessageAndField("The request contains one or more validation errors", "sku", "Product does not exist for SKU: NON-EXISTENT-SKU-12345");
    }

    [Fact]
    public async Task ShouldRejectOrderWithNegativeQuantity()
    {
        var homePage = await _shopUiClient!.OpenHomePageAsync();
        var newOrderPage = await homePage.ClickNewOrderAsync();
        await newOrderPage.InputSkuAsync(CreateUniqueSku(Defaults.SKU));
        await newOrderPage.InputQuantityAsync("-10");
        await newOrderPage.InputCountryAsync(Defaults.COUNTRY);
        await newOrderPage.ClickPlaceOrderAsync();
        var result = await newOrderPage.GetResultAsync();
        result.ShouldBeFailure();
        result.Error.ShouldHaveMessageAndField("The request contains one or more validation errors", "quantity", "Quantity must be positive");
    }

    [Fact]
    public async Task ShouldRejectOrderWithZeroQuantity()
    {
        var homePage = await _shopUiClient!.OpenHomePageAsync();
        var newOrderPage = await homePage.ClickNewOrderAsync();
        await newOrderPage.InputSkuAsync("ANOTHER-SKU-67890");
        await newOrderPage.InputQuantityAsync("0");
        await newOrderPage.InputCountryAsync(Defaults.COUNTRY);
        await newOrderPage.ClickPlaceOrderAsync();
        var result = await newOrderPage.GetResultAsync();
        result.ShouldBeFailure();
        result.Error.ShouldHaveMessageAndField("The request contains one or more validation errors", "quantity", "Quantity must be positive");
    }

    [Theory]
    [ClassData(typeof(EmptyArgumentsProvider))]
    public async Task ShouldRejectOrderWithEmptySku(string sku)
    {
        var homePage = await _shopUiClient!.OpenHomePageAsync();
        var newOrderPage = await homePage.ClickNewOrderAsync();
        await newOrderPage.InputSkuAsync(sku);
        await newOrderPage.InputQuantityAsync(Defaults.QUANTITY);
        await newOrderPage.InputCountryAsync(Defaults.COUNTRY);
        await newOrderPage.ClickPlaceOrderAsync();
        var result = await newOrderPage.GetResultAsync();
        result.ShouldBeFailure();
        result.Error.ShouldHaveMessageAndField("The request contains one or more validation errors", "sku", "SKU must not be empty");
    }

    [Theory]
    [ClassData(typeof(EmptyArgumentsProvider))]
    public async Task ShouldRejectOrderWithEmptyQuantity(string emptyQuantity)
    {
        var homePage = await _shopUiClient!.OpenHomePageAsync();
        var newOrderPage = await homePage.ClickNewOrderAsync();
        await newOrderPage.InputSkuAsync(CreateUniqueSku(Defaults.SKU));
        await newOrderPage.InputQuantityAsync(emptyQuantity);
        await newOrderPage.InputCountryAsync(Defaults.COUNTRY);
        await newOrderPage.ClickPlaceOrderAsync();
        var result = await newOrderPage.GetResultAsync();
        result.ShouldBeFailure();
        result.Error.ShouldHaveMessageAndField("The request contains one or more validation errors", "quantity", "Quantity must not be empty");
    }

    [Theory]
    [InlineData("3.5")]
    [InlineData("lala")]
    public async Task ShouldRejectOrderWithNonIntegerQuantity(string nonIntegerQuantity)
    {
        var homePage = await _shopUiClient!.OpenHomePageAsync();
        var newOrderPage = await homePage.ClickNewOrderAsync();
        await newOrderPage.InputSkuAsync(CreateUniqueSku(Defaults.SKU));
        await newOrderPage.InputQuantityAsync(nonIntegerQuantity);
        await newOrderPage.InputCountryAsync(Defaults.COUNTRY);
        await newOrderPage.ClickPlaceOrderAsync();
        var result = await newOrderPage.GetResultAsync();
        result.ShouldBeFailure();
        result.Error.ShouldHaveMessageAndField("The request contains one or more validation errors", "quantity", "Quantity must be an integer");
    }

    [Fact]
    public async Task ShouldRejectOrderWithEmptyCountry()
    {
        var homePage = await _shopUiClient!.OpenHomePageAsync();
        var newOrderPage = await homePage.ClickNewOrderAsync();
        await newOrderPage.InputSkuAsync(CreateUniqueSku(Defaults.SKU));
        await newOrderPage.InputQuantityAsync(Defaults.QUANTITY);
        await newOrderPage.InputCountryAsync("");
        await newOrderPage.ClickPlaceOrderAsync();
        var result = await newOrderPage.GetResultAsync();
        result.ShouldBeFailure();
        result.Error.ShouldHaveMessageAndField("The request contains one or more validation errors", "country", "Country must not be empty");
    }

    [Fact]
    public async Task ShouldRejectOrderWithInvalidCountry()
    {
        var sku = CreateUniqueSku(Defaults.SKU);
        (await _erpClient!.CreateProductAsync(new ExtCreateProductRequest { Id = sku, Title = "Test", Description = "Test", Category = "Test", Brand = "Test", Price = "20.00" })).ShouldBeSuccess();
        var homePage = await _shopUiClient!.OpenHomePageAsync();
        var newOrderPage = await homePage.ClickNewOrderAsync();
        await newOrderPage.InputSkuAsync(sku);
        await newOrderPage.InputQuantityAsync(Defaults.QUANTITY);
        await newOrderPage.InputCountryAsync("XX");
        await newOrderPage.ClickPlaceOrderAsync();
        var result = await newOrderPage.GetResultAsync();
        result.ShouldBeFailure();
        result.Error.ShouldHaveMessageAndField("The request contains one or more validation errors", "country", "Country does not exist: XX");
    }
}

