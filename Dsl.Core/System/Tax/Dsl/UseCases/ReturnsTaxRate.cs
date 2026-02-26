using Optivem.EShop.SystemTest.Driver.Api.Tax;
using Optivem.EShop.SystemTest.Driver.Api.Tax.Dtos;
using Optivem.EShop.SystemTest.Driver.Api.Tax.Dtos.Error;
using Optivem.EShop.SystemTest.Core.Tax.Dsl.UseCases.Base;
using Common.Util;
using Driver.Shared.Dsl;

namespace Optivem.EShop.SystemTest.Core.Tax.Dsl.UseCases;

public class ReturnsTaxRate : BaseTaxCommand<VoidValue, VoidVerification>
{
    private string? countryAlias;
    private string? taxRate;

    public ReturnsTaxRate(ITaxDriver driver, UseCaseContext context)
        : base(driver, context)
    {
    }

    public ReturnsTaxRate Country(string? countryAlias)
    {
        this.countryAlias = countryAlias;
        return this;
    }

    public ReturnsTaxRate TaxRate(string? taxRate)
    {
        this.taxRate = taxRate;
        return this;
    }

    public ReturnsTaxRate TaxRate(decimal taxRate)
    {
        return TaxRate(taxRate.ToString());
    }

    public override async Task<TaxUseCaseResult<VoidValue, VoidVerification>> Execute()
    {
        var country = _context.GetParamValueOrLiteral(countryAlias);

        var request = new ReturnsTaxRateRequest
        {
            Country = country,
            TaxRate = taxRate
        };

        var result = await _driver.ReturnsTaxRateAsync(request);

        return new TaxUseCaseResult<VoidValue, VoidVerification>(
            result,
            _context,
            (response, ctx) => new VoidVerification(response, ctx));
    }
}
