using Driver.Api.Tax;
using Driver.Api.Tax.Dtos.Error;
using Driver.Core.Tax.Dsl.UseCases.Base;
using Common;
using Dsl.Common;

namespace Driver.Core.Tax.Dsl.UseCases;

public class GoToTax : BaseTaxCommand<VoidValue, VoidVerification>
{
    public GoToTax(ITaxDriver driver, UseCaseContext context)
        : base(driver, context)
    {
    }

    public override async Task<TaxUseCaseResult<VoidValue, VoidVerification>> Execute()
    {
        var result = await _driver.GoToTaxAsync();

        return new TaxUseCaseResult<VoidValue, VoidVerification>(
            result,
            _context,
            (response, ctx) => new VoidVerification(response, ctx));
    }
}


