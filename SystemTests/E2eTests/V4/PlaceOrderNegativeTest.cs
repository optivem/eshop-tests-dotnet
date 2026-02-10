using Commons.Util;
using Optivem.EShop.SystemTest.Core.Erp.Driver.Dtos;
using Optivem.EShop.SystemTest.Core.Shop;
using Optivem.EShop.SystemTest.Core.Shop.Commons.Dtos.Orders;
using Optivem.EShop.SystemTest.E2eTests.Commons.Constants;
using Optivem.EShop.SystemTest.E2eTests.V4.Base;
using Optivem.EShop.SystemTest.E2eTests.V4.Helpers;
using Optivem.Testing;
using Shouldly;
using Xunit;

namespace Optivem.EShop.SystemTest.E2eTests.V4;

public class PlaceOrderNegativeTest : BaseE2eTest
{
    [Theory]
    [ChannelData(ChannelType.UI, ChannelType.API)]
    public async Task ShouldRejectOrderWithInvalidQuantity(Channel channel)
    {
        ChannelContext.Set(channel.Type);
        await InitializeAsync();

        var request = new PlaceOrderRequest { Sku = CreateUniqueSku(Defaults.SKU), Quantity = "invalid-quantity", Country = Defaults.COUNTRY };
        var result = await _shopDriver!.Orders().PlaceOrder(request);

        result.ShouldBeFailure();
        result.Error.ShouldHaveMessageAndField("The request contains one or more validation errors", "quantity", "Quantity must be an integer");
    }

    [Theory]
    [ChannelData(ChannelType.UI, ChannelType.API)]
    public async Task ShouldRejectOrderWithNonExistentSku(Channel channel)
    {
        ChannelContext.Set(channel.Type);
        await InitializeAsync();

        var request = new PlaceOrderRequest { Sku = "NON-EXISTENT-SKU-12345", Quantity = Defaults.QUANTITY, Country = Defaults.COUNTRY };
        var result = await _shopDriver!.Orders().PlaceOrder(request);

        result.ShouldBeFailure();
        result.Error.ShouldHaveMessageAndField("The request contains one or more validation errors", "sku", "Product does not exist for SKU: NON-EXISTENT-SKU-12345");
    }

    [Theory]
    [ChannelData(ChannelType.UI, ChannelType.API)]
    public async Task ShouldRejectOrderWithNegativeQuantity(Channel channel)
    {
        ChannelContext.Set(channel.Type);
        await InitializeAsync();

        var request = new PlaceOrderRequest { Sku = CreateUniqueSku(Defaults.SKU), Quantity = "-10", Country = Defaults.COUNTRY };
        var result = await _shopDriver!.Orders().PlaceOrder(request);

        result.ShouldBeFailure();
        result.Error.ShouldHaveMessageAndField("The request contains one or more validation errors", "quantity", "Quantity must be positive");
    }

    [Theory]
    [ChannelData(ChannelType.UI, ChannelType.API)]
    public async Task ShouldRejectOrderWithZeroQuantity(Channel channel)
    {
        ChannelContext.Set(channel.Type);
        await InitializeAsync();

        var request = new PlaceOrderRequest { Sku = "ANOTHER-SKU-67890", Quantity = "0", Country = Defaults.COUNTRY };
        var result = await _shopDriver!.Orders().PlaceOrder(request);

        result.ShouldBeFailure();
        result.Error.ShouldHaveMessageAndField("The request contains one or more validation errors", "quantity", "Quantity must be positive");
    }

    [Theory]
    [ChannelData(ChannelType.UI, ChannelType.API)]
    [ChannelMemberData(nameof(EmptyValues))]
    public async Task ShouldRejectOrderWithEmptySku(Channel channel, string sku)
    {
        ChannelContext.Set(channel.Type);
        await InitializeAsync();

        var request = new PlaceOrderRequest { Sku = sku, Quantity = Defaults.QUANTITY, Country = Defaults.COUNTRY };
        var result = await _shopDriver!.Orders().PlaceOrder(request);

        result.ShouldBeFailure();
        result.Error.ShouldHaveMessageAndField("The request contains one or more validation errors", "sku", "SKU must not be empty");
    }

    [Theory]
    [ChannelData(ChannelType.UI, ChannelType.API)]
    [ChannelMemberData(nameof(EmptyValues))]
    public async Task ShouldRejectOrderWithEmptyQuantity(Channel channel, string emptyQuantity)
    {
        ChannelContext.Set(channel.Type);
        await InitializeAsync();

        var request = new PlaceOrderRequest { Sku = CreateUniqueSku(Defaults.SKU), Quantity = emptyQuantity, Country = Defaults.COUNTRY };
        var result = await _shopDriver!.Orders().PlaceOrder(request);

        result.ShouldBeFailure();
        result.Error.ShouldHaveMessageAndField("The request contains one or more validation errors", "quantity", "Quantity must not be empty");
    }

    [Theory]
    [ChannelData(ChannelType.UI, ChannelType.API)]
    [ChannelInlineData("3.5")]
    [ChannelInlineData("lala")]
    public async Task ShouldRejectOrderWithNonIntegerQuantity(Channel channel, string nonIntegerQuantity)
    {
        ChannelContext.Set(channel.Type);
        await InitializeAsync();

        var request = new PlaceOrderRequest { Sku = CreateUniqueSku(Defaults.SKU), Quantity = nonIntegerQuantity, Country = Defaults.COUNTRY };
        var result = await _shopDriver!.Orders().PlaceOrder(request);

        result.ShouldBeFailure();
        result.Error.ShouldHaveMessageAndField("The request contains one or more validation errors", "quantity", "Quantity must be an integer");
    }

    [Theory]
    [ChannelData(ChannelType.UI, ChannelType.API)]
    [ChannelMemberData(nameof(EmptyValues))]
    public async Task ShouldRejectOrderWithEmptyCountry(Channel channel, string emptyCountry)
    {
        ChannelContext.Set(channel.Type);
        await InitializeAsync();

        var request = new PlaceOrderRequest { Sku = CreateUniqueSku(Defaults.SKU), Quantity = Defaults.QUANTITY, Country = emptyCountry };
        var result = await _shopDriver!.Orders().PlaceOrder(request);

        result.ShouldBeFailure();
        result.Error.ShouldHaveMessageAndField("The request contains one or more validation errors", "country", "Country must not be empty");
    }

    [Theory]
    [ChannelData(ChannelType.UI, ChannelType.API)]
    [ChannelInlineData("XX")]
    [ChannelInlineData("InvalidCountry")]
    public async Task ShouldRejectOrderWithInvalidCountry(Channel channel, string invalidCountry)
    {
        ChannelContext.Set(channel.Type);
        await InitializeAsync();

        var sku = CreateUniqueSku(Defaults.SKU);
        (await _erpDriver!.ReturnsProduct(new ReturnsProductRequest { Sku = sku, Price = "20.00" })).ShouldBeSuccess();

        var request = new PlaceOrderRequest { Sku = sku, Quantity = Defaults.QUANTITY, Country = invalidCountry };
        var result = await _shopDriver!.Orders().PlaceOrder(request);

        result.ShouldBeFailure();
        result.Error.ShouldHaveMessageAndField("The request contains one or more validation errors", "country", $"Country does not exist: {invalidCountry}");
    }

    [Theory]
    [ChannelData(ChannelType.API)]
    public async Task ShouldRejectOrderWithNullQuantity(Channel channel)
    {
        ChannelContext.Set(channel.Type);
        await InitializeAsync();

        var request = new PlaceOrderRequest { Sku = CreateUniqueSku(Defaults.SKU), Country = Defaults.COUNTRY, Quantity = null };
        var result = await _shopDriver!.Orders().PlaceOrder(request);

        result.ShouldBeFailure();
        result.Error.ShouldHaveMessageAndField("The request contains one or more validation errors", "quantity", "Quantity must not be empty");
    }

    [Theory]
    [ChannelData(ChannelType.API)]
    public async Task ShouldRejectOrderWithNullSku(Channel channel)
    {
        ChannelContext.Set(channel.Type);
        await InitializeAsync();

        var request = new PlaceOrderRequest { Sku = null, Quantity = Defaults.QUANTITY, Country = Defaults.COUNTRY };
        var result = await _shopDriver!.Orders().PlaceOrder(request);

        result.ShouldBeFailure();
        result.Error.ShouldHaveMessageAndField("The request contains one or more validation errors", "sku", "SKU must not be empty");
    }

    [Theory]
    [ChannelData(ChannelType.API)]
    public async Task ShouldRejectOrderWithNullCountry(Channel channel)
    {
        ChannelContext.Set(channel.Type);
        await InitializeAsync();

        var request = new PlaceOrderRequest { Sku = CreateUniqueSku(Defaults.SKU), Quantity = Defaults.QUANTITY, Country = null };
        var result = await _shopDriver!.Orders().PlaceOrder(request);

        result.ShouldBeFailure();
        result.Error.ShouldHaveMessageAndField("The request contains one or more validation errors", "country", "Country must not be empty");
    }

    public static IEnumerable<object[]> EmptyValues()
    {
        yield return new object[] { "" };
        yield return new object[] { "   " };
    }
}
