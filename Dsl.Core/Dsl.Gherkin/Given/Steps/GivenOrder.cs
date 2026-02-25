using Commons.Util;
using Dsl.Api.Given.Steps;
using DslImpl.Gherkin.Given;
using Optivem.EShop.SystemTest.Driver.Api.Shop.Dtos;
using static Optivem.EShop.SystemTest.Core.Gherkin.GherkinDefaults;

namespace Optivem.EShop.SystemTest.Core.Gherkin.Given;

public class GivenOrderBuilder : BaseGivenBuilder, IGivenOrderBuilder
{
    private string? _orderNumber;
    private string? _sku;
    private string? _quantity;
    private string? _country;
    private string? _couponCodeAlias;
    private OrderStatus _status;

    public GivenOrderBuilder(GivenStage givenClause) : base(givenClause)
    {
        WithOrderNumber(DefaultOrderNumber);
        WithSku(DefaultSku);
        WithQuantity(DefaultQuantity);
        WithCountry(DefaultCountry);
        WithCouponCode(Empty);
        WithStatus(DefaultOrderStatus);
    }

    public GivenOrderBuilder WithOrderNumber(string orderNumber)
    {
        _orderNumber = orderNumber;
        return this;
    }

    IGivenOrderBuilder IGivenOrderBuilder.WithOrderNumber(string orderNumber) => WithOrderNumber(orderNumber);

    public GivenOrderBuilder WithSku(string? sku)
    {
        _sku = sku;
        return this;
    }

    IGivenOrderBuilder IGivenOrderBuilder.WithSku(string? sku) => WithSku(sku);

    public GivenOrderBuilder WithQuantity(string? quantity)
    {
        _quantity = quantity;
        return this;
    }

    IGivenOrderBuilder IGivenOrderBuilder.WithQuantity(string? quantity) => WithQuantity(quantity);

    public GivenOrderBuilder WithQuantity(int? quantity)
    {
        return WithQuantity(Converter.FromInteger(quantity));
    }

    IGivenOrderBuilder IGivenOrderBuilder.WithQuantity(int? quantity) => WithQuantity(quantity);

    public GivenOrderBuilder WithCountry(string? country)
    {
        _country = country;
        return this;
    }

    IGivenOrderBuilder IGivenOrderBuilder.WithCountry(string? country) => WithCountry(country);

    public GivenOrderBuilder WithCouponCode(string? couponCodeAlias)
    {
        _couponCodeAlias = couponCodeAlias;
        return this;
    }

    IGivenOrderBuilder IGivenOrderBuilder.WithCouponCode(string? couponCode) => WithCouponCode(couponCode);

    public GivenOrderBuilder WithStatus(OrderStatus status)
    {
        _status = status;
        return this;
    }

    IGivenOrderBuilder IGivenOrderBuilder.WithStatus(OrderStatus status) => WithStatus(status);

    internal override async Task Execute(SystemDsl app)
    {
        var shop = await app.Shop(Channel);

        (await shop.PlaceOrder()
            .OrderNumber(_orderNumber)
            .Sku(_sku)
            .Quantity(_quantity)
            .Country(_country)
            .CouponCode(_couponCodeAlias)
            .Execute())
            .ShouldSucceed();

        if (_status == OrderStatus.Cancelled)
        {
            (await shop.CancelOrder()
                .OrderNumber(_orderNumber)
                .Execute())
                .ShouldSucceed();
        }
    }
}
