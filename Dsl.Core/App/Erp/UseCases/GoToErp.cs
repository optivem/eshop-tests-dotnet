using Driver.Port.Erp;
using Driver.Port.Erp.Dtos.Error;
using Dsl.Core.Erp.UseCases.Base;
using Common;
using Dsl.Common;

namespace Dsl.Core.Erp.UseCases;

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



