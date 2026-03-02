using Driver.Port.Tax;
using Driver.Port.Tax.Dtos;
using Driver.Port.Tax.Dtos.Error;
using Dsl.Core.Tax.UseCases.Base;
using Dsl.Common;

namespace Dsl.Core.Tax.UseCases;

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



