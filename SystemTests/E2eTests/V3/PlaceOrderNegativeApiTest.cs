using Common;
using Driver.Api.Shop.Dtos;
using SystemTests.E2eTests.Commons.Constants;
using SystemTests.E2eTests.V4.Helpers;
using SystemTests.TestInfrastructure.Base.V3;
using Shouldly;
using Xunit;

namespace SystemTests.E2eTests.V3;

public class PlaceOrderNegativeApiTest : PlaceOrderNegativeBaseTest
{
    protected override Task SetShopDriverAsync()
    {
        SetUpShopApiDriver();
        return Task.CompletedTask;
    }

    [Fact]
    public async Task ShouldRejectOrderWithNullQuantity()
    {
        var request = new PlaceOrderRequest { Sku = CreateUniqueSku(Defaults.SKU), Country = Defaults.COUNTRY, Quantity = null };
        var result = await _shopDriver!.PlaceOrderAsync(request);
        result.ShouldBeFailure();
        result.Error.ShouldHaveMessageAndField("The request contains one or more validation errors", "quantity", "Quantity must not be empty");
    }

    [Fact]
    public async Task ShouldRejectOrderWithNullSku()
    {
        var request = new PlaceOrderRequest { Sku = null, Quantity = Defaults.QUANTITY, Country = Defaults.COUNTRY };
        var result = await _shopDriver!.PlaceOrderAsync(request);
        result.ShouldBeFailure();
        result.Error.ShouldHaveMessageAndField("The request contains one or more validation errors", "sku", "SKU must not be empty");
    }

    [Fact]
    public async Task ShouldRejectOrderWithNullCountry()
    {
        var request = new PlaceOrderRequest { Sku = CreateUniqueSku(Defaults.SKU), Quantity = Defaults.QUANTITY, Country = null };
        var result = await _shopDriver!.PlaceOrderAsync(request);
        result.ShouldBeFailure();
        result.Error.ShouldHaveMessageAndField("The request contains one or more validation errors", "country", "Country must not be empty");
    }
}





