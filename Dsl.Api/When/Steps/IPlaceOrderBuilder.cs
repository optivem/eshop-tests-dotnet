using Dsl.Api.When.Steps.Base;

namespace Dsl.Api.When.Steps;

public interface IPlaceOrderBuilder : IWhenStep
{
    IPlaceOrderBuilder WithOrderNumber(string? orderNumber);

    IPlaceOrderBuilder WithSku(string? sku);

    IPlaceOrderBuilder WithQuantity(string? quantity);

    IPlaceOrderBuilder WithQuantity(int quantity);

    IPlaceOrderBuilder WithCountry(string? country);

    IPlaceOrderBuilder WithCouponCode(string? couponCode);

    IPlaceOrderBuilder WithCouponCode();
}