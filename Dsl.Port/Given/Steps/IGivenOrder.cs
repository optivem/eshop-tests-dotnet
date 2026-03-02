using Dsl.Api.Given.Steps.Base;
using Driver.Api.Shop.Dtos;

namespace Dsl.Api.Given.Steps;

public interface IGivenOrder : IGivenStep
{
    IGivenOrder WithOrderNumber(string orderNumber);

    IGivenOrder WithSku(string? sku);

    IGivenOrder WithQuantity(string? quantity);

    IGivenOrder WithQuantity(int? quantity);

    IGivenOrder WithCountry(string? country);

    IGivenOrder WithCouponCode(string? couponCode);

    IGivenOrder WithStatus(OrderStatus status);
}
