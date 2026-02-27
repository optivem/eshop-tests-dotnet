using DslImpl.Scenario.When;
using Dsl.Api.When.Steps;
using Dsl.Common;
using Common;
using Optivem.EShop.SystemTest.Core;
using Driver.Api.Shop.Dtos;
using Optivem.EShop.SystemTest.Core.Shop.Dsl.UseCases;
using Optivem.Testing;
using static Optivem.EShop.SystemTest.Core.Gherkin.GherkinDefaults;

namespace DslImpl.Scenario.Builders.When.PlaceOrder;

public class PlaceOrder : BaseWhen<PlaceOrderResponse, PlaceOrderVerification>, IPlaceOrder
{
    private string? _orderNumber;
    private string? _sku;
    private string? _quantity;
    private string? _country;
    private string? _couponCode;

    public PlaceOrder(SystemDsl app, ScenarioDsl scenario, Func<Task> ensureGiven) : base(app, scenario, ensureGiven)
    {
        WithOrderNumber(DefaultOrderNumber);
        WithSku(DefaultSku);
        WithQuantity(DefaultQuantity);
        WithCountry(DefaultCountry);
        WithCouponCode(Empty);
    }

    public PlaceOrder WithOrderNumber(string? orderNumber)
    {
        _orderNumber = orderNumber;
        return this;
    }

    IPlaceOrder IPlaceOrder.WithOrderNumber(string? orderNumber) => WithOrderNumber(orderNumber);

    public PlaceOrder WithSku(string? sku)
    {
        _sku = sku;
        return this;
    }

    IPlaceOrder IPlaceOrder.WithSku(string? sku) => WithSku(sku);

    public PlaceOrder WithQuantity(string? quantity)
    {
        _quantity = quantity;
        return this;
    }

    IPlaceOrder IPlaceOrder.WithQuantity(string? quantity) => WithQuantity(quantity);

    public PlaceOrder WithQuantity(int quantity)
    {
        return WithQuantity(Converter.FromInteger(quantity));
    }

    IPlaceOrder IPlaceOrder.WithQuantity(int quantity) => WithQuantity(quantity);

    public PlaceOrder WithCountry(string? country)
    {
        _country = country;
        return this;
    }

    IPlaceOrder IPlaceOrder.WithCountry(string? country) => WithCountry(country);

    public PlaceOrder WithCouponCode(string? couponCode)
    {
        _couponCode = couponCode;
        return this;
    }

    IPlaceOrder IPlaceOrder.WithCouponCode(string? couponCode) => WithCouponCode(couponCode);

    public PlaceOrder WithCouponCode()
    {
        return WithCouponCode(DefaultCouponCode);
    }

    IPlaceOrder IPlaceOrder.WithCouponCode() => WithCouponCode();

    protected override async Task<ExecutionResult<PlaceOrderResponse, PlaceOrderVerification>> Execute(SystemDsl app)
    {
        var shop = await app.Shop(Channel);
        var result = await shop.PlaceOrder()
            .OrderNumber(_orderNumber)
            .Sku(_sku)
            .Quantity(_quantity)
            .Country(_country)
            .CouponCode(_couponCode)
            .Execute();

        return new ExecutionResultBuilder<PlaceOrderResponse, PlaceOrderVerification>(result)
            .OrderNumber(_orderNumber)
            .CouponCode(_couponCode)
            .Build();
    }
}

