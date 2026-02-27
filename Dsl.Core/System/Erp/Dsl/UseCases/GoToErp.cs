using Optivem.EShop.SystemTest.Driver.Api.Erp;
using Optivem.EShop.SystemTest.Driver.Api.Erp.Dtos.Error;
using Optivem.EShop.SystemTest.Core.Erp.Dsl.UseCases.Base;
using Common;
using Driver.Shared.Dsl;

namespace Optivem.EShop.SystemTest.Core.Erp.Dsl.UseCases;

public class GoToErp : BaseErpCommand<VoidValue, VoidVerification>
{
    public GoToErp(IErpDriver driver, UseCaseContext context)
        : base(driver, context)
    {
    }

    public override async Task<ErpUseCaseResult<VoidValue, VoidVerification>> Execute()
    {
        var result = await _driver.GoToErpAsync();

        return new ErpUseCaseResult<VoidValue, VoidVerification>(
            result,
            _context,
            (response, ctx) => new VoidVerification(response, ctx));
    }
}
