using Optivem.EShop.SystemTest.Driver.Api.Tax;
using Optivem.EShop.SystemTest.Driver.Api.Tax.Dtos;
using Optivem.EShop.SystemTest.Driver.Api.Tax.Dtos.Error;
using Optivem.EShop.SystemTest.Dsl.Tax.Dsl.UseCases.Base;
using Driver.Core.Driver.Commons.Dsl;

namespace Optivem.EShop.SystemTest.Dsl.Tax.Dsl.UseCases;

public class GetTaxRate : BaseTaxCommand<GetTaxResponse, GetTaxVerification>
{
    private string? country;

    public GetTaxRate(ITaxDriver driver, Driver.Core.Driver.Commons.Dsl.UseCaseContext context)
        : base(driver, context)
    {
    }

    public GetTaxRate Country(string? country)
    {
        this.country = country;
        return this;
    }

    public override async Task<TaxDriver.Core.Driver.Commons.Dsl.UseCaseResult<GetTaxResponse, GetTaxVerification>> Execute()
    {
        var countryValue = _context.GetParamValueOrLiteral(country);

        var result = await _driver.GetTaxRateAsync(countryValue);

        return new TaxDriver.Core.Driver.Commons.Dsl.UseCaseResult<GetTaxResponse, GetTaxVerification>(
            result,
            _context,
            (response, ctx) => new GetTaxVerification(response, ctx));
    }
}
