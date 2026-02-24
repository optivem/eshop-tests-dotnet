using Optivem.EShop.SystemTest.Driver.Api.Tax;
using Optivem.EShop.SystemTest.Driver.Api.Tax.Dtos.Error;
using Optivem.EShop.SystemTest.Dsl.Tax.Dsl.UseCases.Base;
using Commons.Util;
using Driver.Core.Driver.Commons.Dsl;

namespace Optivem.EShop.SystemTest.Dsl.Tax.Dsl.UseCases;

public class GoToTax : BaseTaxCommand<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>
{
    public GoToTax(ITaxDriver driver, Driver.Core.Driver.Commons.Dsl.UseCaseContext context)
        : base(driver, context)
    {
    }

    public override async Task<TaxDriver.Core.Driver.Commons.Dsl.UseCaseResult<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>> Execute()
    {
        var result = await _driver.GoToTaxAsync();

        return new TaxDriver.Core.Driver.Commons.Dsl.UseCaseResult<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>(
            result,
            _context,
            (response, ctx) => new Driver.Core.Driver.Commons.Dsl.VoidVerification(response, ctx));
    }
}
