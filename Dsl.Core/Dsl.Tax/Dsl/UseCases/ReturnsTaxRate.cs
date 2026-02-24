using Optivem.EShop.SystemTest.Driver.Api.Tax;
using Optivem.EShop.SystemTest.Driver.Api.Tax.Dtos;
using Optivem.EShop.SystemTest.Driver.Api.Tax.Dtos.Error;
using Optivem.EShop.SystemTest.Dsl.Tax.Dsl.UseCases.Base;
using Commons.Util;
using Driver.Core.Driver.Commons.Dsl;

namespace Optivem.EShop.SystemTest.Dsl.Tax.Dsl.UseCases;

public class ReturnsTaxRate : BaseTaxCommand<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>
{
    private string? countryAlias;
    private string? taxRate;

    public ReturnsTaxRate(ITaxDriver driver, Driver.Core.Driver.Commons.Dsl.UseCaseContext context)
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

    public override async Task<TaxDriver.Core.Driver.Commons.Dsl.UseCaseResult<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>> Execute()
    {
        var country = _context.GetParamValueOrLiteral(countryAlias);

        var request = new ReturnsTaxRateRequest
        {
            Country = country,
            TaxRate = taxRate
        };

        var result = await _driver.ReturnsTaxRateAsync(request);

        return new TaxDriver.Core.Driver.Commons.Dsl.UseCaseResult<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>(
            result,
            _context,
            (response, ctx) => new Driver.Core.Driver.Commons.Dsl.VoidVerification(response, ctx));
    }
}
