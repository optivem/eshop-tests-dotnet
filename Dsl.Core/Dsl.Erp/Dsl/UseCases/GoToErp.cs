using Optivem.EShop.SystemTest.Driver.Api.Erp;
using Optivem.EShop.SystemTest.Driver.Api.Erp.Dtos.Error;
using Optivem.EShop.SystemTest.Dsl.Erp.Dsl.UseCases.Base;
using Commons.Util;
using Driver.Core.Driver.Commons.Dsl;

namespace Optivem.EShop.SystemTest.Dsl.Erp.Dsl.UseCases;

public class GoToErp : BaseErpCommand<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>
{
    public GoToErp(IErpDriver driver, Driver.Core.Driver.Commons.Dsl.UseCaseContext context)
        : base(driver, context)
    {
    }

    public override async Task<ErpDriver.Core.Driver.Commons.Dsl.UseCaseResult<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>> Execute()
    {
        var result = await _driver.GoToErpAsync();

        return new ErpDriver.Core.Driver.Commons.Dsl.UseCaseResult<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>(
            result,
            _context,
            (response, ctx) => new Driver.Core.Driver.Commons.Dsl.VoidVerification(response, ctx));
    }
}
