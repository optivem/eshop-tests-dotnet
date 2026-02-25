using Dsl.Api.Given.Steps.Base;
using Optivem.EShop.SystemTest.Driver.Api.Shop.Dtos;

namespace Dsl.Api.Given.Steps;

public interface IGivenOrderBuilder : IGivenStep
{
    IGivenOrderBuilder WithOrderNumber(string orderNumber);

    IGivenOrderBuilder WithSku(string? sku);

    IGivenOrderBuilder WithQuantity(string? quantity);

    IGivenOrderBuilder WithQuantity(int? quantity);

    IGivenOrderBuilder WithCountry(string? country);

    IGivenOrderBuilder WithCouponCode(string? couponCode);

    IGivenOrderBuilder WithStatus(OrderStatus status);
}