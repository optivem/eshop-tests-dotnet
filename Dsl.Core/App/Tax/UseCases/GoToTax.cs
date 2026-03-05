using Driver.Port.Tax;
using Driver.Port.Tax.Dtos.Error;
using Dsl.Core.Tax.UseCases.Base;
using Common;
using Dsl.Core.Shared;

namespace Dsl.Core.Tax.UseCases;

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



