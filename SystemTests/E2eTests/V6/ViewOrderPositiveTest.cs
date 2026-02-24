using Optivem.EShop.SystemTest.Core.Shop;
using Optivem.EShop.SystemTest.Driver.Ports.Shop.Dtos;
using Optivem.EShop.SystemTest.E2eTests.Commons.Constants;
using Optivem.EShop.SystemTest.E2eTests.V6.Base;
using Optivem.Testing;
using Xunit;

namespace Optivem.EShop.SystemTest.E2eTests.V6;

public class ViewOrderPositiveTest : BaseE2eTest
{
    [Theory]
    [ChannelData(ChannelType.UI, ChannelType.API)]
    public async Task ShouldViewPlacedOrder(Channel channel)
    {
        await Scenario(channel)
            .Given().Product()
                .WithSku(Defaults.SKU)
                .WithUnitPrice("25.00")
            .And().Order()
                .WithOrderNumber(Defaults.ORDER_NUMBER)
                .WithSku(Defaults.SKU)
                .WithCountry(Defaults.COUNTRY)
                .WithQuantity(4)
            .When().ViewOrder()
                .WithOrderNumber(Defaults.ORDER_NUMBER)
            .Then().ShouldSucceed()
            .And().Order(Defaults.ORDER_NUMBER)
                .HasSku(Defaults.SKU)
                .HasQuantity(4)
                .HasCountry(Defaults.COUNTRY)
                .HasUnitPrice(25.00m)
                .HasSubtotalPrice("100.00")
                .HasStatus(OrderStatus.Placed)
                .HasDiscountRateGreaterThanOrEqualToZero()
                .HasDiscountAmountGreaterThanOrEqualToZero()
                .HasSubtotalPriceGreaterThanZero()
                .HasTaxRateGreaterThanOrEqualToZero()
                .HasTaxAmountGreaterThanOrEqualToZero()
                .HasTotalPriceGreaterThanZero();
    }
}

