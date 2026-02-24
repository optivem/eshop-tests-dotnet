using Optivem.EShop.SystemTest.Driver.Ports.Tax;
using Optivem.EShop.SystemTest.Driver.Ports.Tax.Dtos;
using Optivem.EShop.SystemTest.Driver.Ports.Tax.Dtos.Error;
using Optivem.EShop.SystemTest.Core.Tax.Dsl.UseCases.Base;
using Driver.Impl.Commons.Dsl;

namespace Optivem.EShop.SystemTest.Core.Tax.Dsl.UseCases;

public class GetTaxRate : BaseTaxCommand<GetTaxResponse, GetTaxVerification>
{
    private string? country;

    public GetTaxRate(ITaxDriver driver, UseCaseContext context)
        : base(driver, context)
    {
    }

    public GetTaxRate Country(string? country)
    {
        this.country = country;
        return this;
    }

    public override async Task<TaxUseCaseResult<GetTaxResponse, GetTaxVerification>> Execute()
    {
        var countryValue = _context.GetParamValueOrLiteral(country);

        var result = await _driver.GetTaxRateAsync(countryValue);

        return new TaxUseCaseResult<GetTaxResponse, GetTaxVerification>(
            result,
            _context,
            (response, ctx) => new GetTaxVerification(response, ctx));
    }
}
