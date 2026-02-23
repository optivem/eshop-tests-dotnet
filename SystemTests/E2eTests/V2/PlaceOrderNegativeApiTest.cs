using Commons.Util;
using Optivem.EShop.SystemTest.Infra.Erp.Client.Dtos;
using Optivem.EShop.SystemTest.Core.Shop.Driver.Dtos.Error;
using Optivem.EShop.SystemTest.Core.Shop.Driver.Dtos.Orders;
using Optivem.EShop.SystemTest.E2eTests.Commons.Constants;
using Optivem.EShop.SystemTest.E2eTests.V2.Base;
using Optivem.EShop.SystemTest.E2eTests.V4.Helpers;
using E2eTests.Providers;
using Optivem.EShop.SystemTest.Base.V2;
using Optivem.EShop.SystemTest.Infra.Shop.Client.Api.Dtos.Errors;
using Shouldly;
using Xunit;

namespace Optivem.EShop.SystemTest.E2eTests.V2;

public class PlaceOrderNegativeApiTest : BaseE2eTest
{
    protected override Task SetShopClientAsync()
    {
        SetUpShopApiClient();
        return Task.CompletedTask;
    }

    [Fact]
    public async Task ShouldRejectOrderWithInvalidQuantity()
    {
        var request = new PlaceOrderRequest { Sku = CreateUniqueSku(Defaults.SKU), Quantity = "invalid-quantity", Country = Defaults.COUNTRY };
        var result = await _shopApiClient!.Orders().PlaceOrderAsync(request);
        result.ShouldBeFailure();
        result.Error.Detail.ShouldBe("The request contains one or more validation errors");
        result.Error.Errors.ShouldNotBeNull();
        result.Error.Errors.ShouldContain(e => e.Field == "quantity" && e.Message == "Quantity must be an integer");
    }

    [Fact]
    public async Task ShouldRejectOrderWithNonExistentSku()
    {
        var request = new PlaceOrderRequest { Sku = "NON-EXISTENT-SKU-12345", Quantity = Defaults.QUANTITY, Country = Defaults.COUNTRY };
        var result = await _shopApiClient!.Orders().PlaceOrderAsync(request);
        result.ShouldBeFailure();
        result.Error.Detail.ShouldBe("The request contains one or more validation errors");
        result.Error.Errors.ShouldNotBeNull();
        result.Error.Errors.ShouldContain(e => e.Field == "sku" && e.Message == "Product does not exist for SKU: NON-EXISTENT-SKU-12345");
    }

    [Fact]
    public async Task ShouldRejectOrderWithNegativeQuantity()
    {
        var request = new PlaceOrderRequest { Sku = CreateUniqueSku(Defaults.SKU), Quantity = "-10", Country = Defaults.COUNTRY };
        var result = await _shopApiClient!.Orders().PlaceOrderAsync(request);
        result.ShouldBeFailure();
        result.Error.Detail.ShouldBe("The request contains one or more validation errors");
        result.Error.Errors.ShouldNotBeNull();
        result.Error.Errors.ShouldContain(e => e.Field == "quantity" && e.Message == "Quantity must be positive");
    }

    [Fact]
    public async Task ShouldRejectOrderWithZeroQuantity()
    {
        var request = new PlaceOrderRequest { Sku = CreateUniqueSku(Defaults.SKU), Quantity = "0", Country = Defaults.COUNTRY };
        var result = await _shopApiClient!.Orders().PlaceOrderAsync(request);
        result.ShouldBeFailure();
        result.Error.Detail.ShouldBe("The request contains one or more validation errors");
        result.Error.Errors.ShouldNotBeNull();
        result.Error.Errors.ShouldContain(e => e.Field == "quantity" && e.Message == "Quantity must be positive");
    }

    [Theory]
    [ClassData(typeof(EmptyArgumentsProvider))]
    public async Task ShouldRejectOrderWithEmptySku(string sku)
    {
        var request = new PlaceOrderRequest { Sku = sku, Quantity = Defaults.QUANTITY, Country = Defaults.COUNTRY };
        var result = await _shopApiClient!.Orders().PlaceOrderAsync(request);
        result.ShouldBeFailure();
        result.Error.Detail.ShouldBe("The request contains one or more validation errors");
        result.Error.Errors.ShouldNotBeNull();
        result.Error.Errors.ShouldContain(e => e.Field == "sku" && e.Message == "SKU must not be empty");
    }

    [Fact]
    public async Task ShouldRejectOrderWithEmptyQuantity()
    {
        var request = new PlaceOrderRequest { Sku = CreateUniqueSku(Defaults.SKU), Quantity = "", Country = Defaults.COUNTRY };
        var result = await _shopApiClient!.Orders().PlaceOrderAsync(request);
        result.ShouldBeFailure();
        result.Error.Detail.ShouldBe("The request contains one or more validation errors");
        result.Error.Errors.ShouldNotBeNull();
        result.Error.Errors.ShouldContain(e => e.Field == "quantity" && e.Message == "Quantity must not be empty");
    }

    [Fact]
    public async Task ShouldRejectOrderWithNonIntegerQuantity()
    {
        var request = new PlaceOrderRequest { Sku = CreateUniqueSku(Defaults.SKU), Quantity = "3.5", Country = Defaults.COUNTRY };
        var result = await _shopApiClient!.Orders().PlaceOrderAsync(request);
        result.ShouldBeFailure();
        result.Error.Detail.ShouldBe("The request contains one or more validation errors");
        result.Error.Errors.ShouldNotBeNull();
        result.Error.Errors.ShouldContain(e => e.Field == "quantity" && e.Message == "Quantity must be an integer");
    }

    [Fact]
    public async Task ShouldRejectOrderWithEmptyCountry()
    {
        var request = new PlaceOrderRequest { Sku = CreateUniqueSku(Defaults.SKU), Quantity = Defaults.QUANTITY, Country = "" };
        var result = await _shopApiClient!.Orders().PlaceOrderAsync(request);
        result.ShouldBeFailure();
        result.Error.Detail.ShouldBe("The request contains one or more validation errors");
        result.Error.Errors.ShouldNotBeNull();
        result.Error.Errors.ShouldContain(e => e.Field == "country" && e.Message == "Country must not be empty");
    }

    [Fact]
    public async Task ShouldRejectOrderWithInvalidCountry()
    {
        var sku = CreateUniqueSku(Defaults.SKU);
        (await _erpClient!.CreateProductAsync(new ExtCreateProductRequest { Id = sku, Title = "Test", Description = "Test", Category = "Test", Brand = "Test", Price = "20.00" })).ShouldBeSuccess();
        var request = new PlaceOrderRequest { Sku = sku, Quantity = Defaults.QUANTITY, Country = "XX" };
        var result = await _shopApiClient!.Orders().PlaceOrderAsync(request);
        result.ShouldBeFailure();
        result.Error.Detail.ShouldBe("The request contains one or more validation errors");
        result.Error.Errors.ShouldNotBeNull();
        result.Error.Errors.ShouldContain(e => e.Field == "country" && e.Message == "Country does not exist: XX");
    }

    [Fact]
    public async Task ShouldRejectOrderWithNullQuantity()
    {
        var request = new PlaceOrderRequest { Sku = CreateUniqueSku(Defaults.SKU), Country = Defaults.COUNTRY, Quantity = null };
        var result = await _shopApiClient!.Orders().PlaceOrderAsync(request);
        result.ShouldBeFailure();
        result.Error.Detail.ShouldBe("The request contains one or more validation errors");
        result.Error.Errors.ShouldNotBeNull();
        result.Error.Errors.ShouldContain(e => e.Field == "quantity" && e.Message == "Quantity must not be empty");
    }

    [Fact]
    public async Task ShouldRejectOrderWithNullSku()
    {
        var request = new PlaceOrderRequest { Sku = null, Quantity = Defaults.QUANTITY, Country = Defaults.COUNTRY };
        var result = await _shopApiClient!.Orders().PlaceOrderAsync(request);
        result.ShouldBeFailure();
        result.Error.Detail.ShouldBe("The request contains one or more validation errors");
        result.Error.Errors.ShouldNotBeNull();
        result.Error.Errors.ShouldContain(e => e.Field == "sku" && e.Message == "SKU must not be empty");
    }

    [Fact]
    public async Task ShouldRejectOrderWithNullCountry()
    {
        var request = new PlaceOrderRequest { Sku = CreateUniqueSku(Defaults.SKU), Quantity = Defaults.QUANTITY, Country = null };
        var result = await _shopApiClient!.Orders().PlaceOrderAsync(request);
        result.ShouldBeFailure();
        result.Error.Detail.ShouldBe("The request contains one or more validation errors");
        result.Error.Errors.ShouldNotBeNull();
        result.Error.Errors.ShouldContain(e => e.Field == "country" && e.Message == "Country must not be empty");
    }
}
