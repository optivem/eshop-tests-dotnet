using Optivem.EShop.SystemTest.Driver.Api.Tax.Dtos;
using Driver.Core.Driver.Commons.Dsl;
using Commons.Util;
using Shouldly;

namespace Optivem.EShop.SystemTest.Dsl.Tax.Dsl.UseCases;

public class GetTaxVerification : Driver.Core.Driver.Commons.Dsl.ResponseVerification<GetTaxResponse>
{
    public GetTaxVerification(GetTaxResponse response, Driver.Core.Driver.Commons.Dsl.UseCaseContext context)
        : base(response, context)
    {
    }

    public GetTaxVerification Country(string expectedCountryAlias)
    {
        var expectedCountry = Context.GetParamValueOrLiteral(expectedCountryAlias);
        var actualCountry = Response.Country;
        actualCountry.ShouldBe(expectedCountry, $"Expected country to be '{expectedCountry}', but was '{actualCountry}'");
        return this;
    }

    public GetTaxVerification TaxRate(decimal expectedTaxRate)
    {
        var actualTaxRate = Response.TaxRate;
        actualTaxRate.ShouldBe(expectedTaxRate, $"Expected tax rate to be {expectedTaxRate}, but was {actualTaxRate}");
        return this;
    }

    public GetTaxVerification TaxRate(string expectedTaxRate)
    {
        return TaxRate(Converter.ToDecimal(expectedTaxRate)!.Value);
    }

    public GetTaxVerification TaxRateIsPositive()
    {
        var actualTaxRate = Response.TaxRate;
        actualTaxRate.ShouldBeGreaterThan(0m, $"Expected tax rate to be positive, but was {actualTaxRate}");
        return this;
    }
}
