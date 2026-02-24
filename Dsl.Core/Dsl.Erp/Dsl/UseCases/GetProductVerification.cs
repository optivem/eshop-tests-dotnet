using Optivem.EShop.SystemTest.Driver.Api.Erp.Dtos;
using Driver.Core.Driver.Commons.Dsl;
using Shouldly;

namespace Optivem.EShop.SystemTest.Dsl.Erp.Dsl.UseCases;

public class GetProductVerification : Driver.Core.Driver.Commons.Dsl.ResponseVerification<GetProductResponse>
{
    public GetProductVerification(GetProductResponse response, Driver.Core.Driver.Commons.Dsl.UseCaseContext context)
        : base(response, context)
    {
    }

    public GetProductVerification Sku(string skuParamAlias)
    {
        var expectedSku = Context.GetParamValue(skuParamAlias);
        var actualSku = Response.Sku;
        actualSku.ShouldBe(expectedSku, $"Expected SKU to be '{expectedSku}', but was '{actualSku}'");
        return this;
    }

    public GetProductVerification Price(decimal expectedPrice)
    {
        var actualPrice = Response.Price;
        actualPrice.ShouldBe(expectedPrice, $"Expected price to be {expectedPrice}, but was {actualPrice}");
        return this;
    }

    public GetProductVerification Price(string expectedPrice)
    {
        return Price(decimal.Parse(expectedPrice));
    }
}
