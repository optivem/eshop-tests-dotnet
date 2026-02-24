using Commons.Util;
using Optivem.EShop.SystemTest.Driver.Ports.Erp.Dtos;
using Optivem.EShop.SystemTest.Core.Shop;
using Optivem.EShop.SystemTest.Driver.Ports.Shop.Dtos;
using Optivem.EShop.SystemTest.E2eTests.Commons.Constants;
using Optivem.EShop.SystemTest.E2eTests.V4.Base;
using Optivem.Testing;
using Shouldly;
using Xunit;

namespace Optivem.EShop.SystemTest.E2eTests.V4;

public class ViewOrderPositiveTest : BaseE2eTest
{
    [Theory]
    [ChannelData(ChannelType.UI, ChannelType.API)]
    public async Task ShouldViewPlacedOrder(Channel channel)
    {
        await SetChannelAsync(channel);

        var sku = CreateUniqueSku(Defaults.SKU);
        (await _erpDriver!.ReturnsProductAsync(new ReturnsProductRequest 
        { 
            Sku = sku, 
            Price = "25.00" 
        })).ShouldBeSuccess();

        var placeOrderRequest = new PlaceOrderRequest 
        { 
            Sku = sku, 
            Quantity = "4", 
            Country = Defaults.COUNTRY 
        };
        var placeOrderResult = await _shopDriver!.PlaceOrderAsync(placeOrderRequest);
        placeOrderResult.ShouldBeSuccess();

        var orderNumber = placeOrderResult.Value.OrderNumber;

        var viewOrderResult = await _shopDriver.ViewOrderAsync(orderNumber);
        viewOrderResult.ShouldBeSuccess();

        var order = viewOrderResult.Value!;
        order.OrderNumber.ShouldBe(orderNumber);
        order.Sku.ShouldBe(sku);
        order.Country.ShouldBe(Defaults.COUNTRY);
        order.Quantity.ShouldBe(4);
        order.UnitPrice.ShouldBe(25.00m);
        order.SubtotalPrice.ShouldBe(100.00m);
        order.Status.ShouldBe(OrderStatus.Placed);
        order.DiscountRate.ShouldBeGreaterThanOrEqualTo(0);
        order.DiscountAmount.ShouldBeGreaterThanOrEqualTo(0);
        order.SubtotalPrice.ShouldBeGreaterThan(0);
        order.TaxRate.ShouldBeGreaterThanOrEqualTo(0);
        order.TaxAmount.ShouldBeGreaterThanOrEqualTo(0);
        order.TotalPrice.ShouldBeGreaterThan(0);
    }
}


