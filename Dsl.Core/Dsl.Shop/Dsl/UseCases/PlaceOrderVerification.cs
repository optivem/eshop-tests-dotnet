using Driver.Core.Driver.Commons.Dsl;
using Shouldly;
using Optivem.EShop.SystemTest.Driver.Api.Shop.Dtos;

namespace Optivem.EShop.SystemTest.Dsl.Shop.Dsl.UseCases;

public class PlaceOrderVerification : Driver.Core.Driver.Commons.Dsl.ResponseVerification<PlaceOrderResponse>
{
    public PlaceOrderVerification(PlaceOrderResponse response, Driver.Core.Driver.Commons.Dsl.UseCaseContext context)
        : base(response, context)
    {
    }

    public PlaceOrderVerification OrderNumber(string orderNumberResultAlias)
    {
        var expectedOrderNumber = Context.GetResultValue(orderNumberResultAlias);
        var actualOrderNumber = Response.OrderNumber;

        actualOrderNumber.ShouldBe(expectedOrderNumber, $"Expected order number to be '{expectedOrderNumber}', but was '{actualOrderNumber}'");

        return this;
    }

    public PlaceOrderVerification OrderNumberStartsWith(string prefix)
    {
        Response.OrderNumber.ShouldStartWith(prefix, Case.Sensitive, $"Expected order number to start with '{prefix}', but was '{Response.OrderNumber}'");
        return this;
    }
}
