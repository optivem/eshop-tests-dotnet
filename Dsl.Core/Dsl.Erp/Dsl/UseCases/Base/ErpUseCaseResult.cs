using Optivem.EShop.SystemTest.Driver.Api.Erp.Dtos.Error;
using Commons.Util;
using Driver.Core.Driver.Commons.Dsl;

namespace Optivem.EShop.SystemTest.Dsl.Erp.Dsl.UseCases.Base;

public class ErpDriver.Core.Driver.Commons.Dsl.UseCaseResult<TSuccessResponse, TSuccessVerification>
    : Driver.Core.Driver.Commons.Dsl.UseCaseResult<TSuccessResponse, ErpErrorResponse, TSuccessVerification, ErpErrorVerification>
    where TSuccessVerification : Driver.Core.Driver.Commons.Dsl.ResponseVerification<TSuccessResponse>
{
    public ErpDriver.Core.Driver.Commons.Dsl.UseCaseResult(
        Result<TSuccessResponse, ErpErrorResponse> result,
        Driver.Core.Driver.Commons.Dsl.UseCaseContext context,
        Func<TSuccessResponse, Driver.Core.Driver.Commons.Dsl.UseCaseContext, TSuccessVerification> verificationFactory)
        : base(result, context, verificationFactory, (error, ctx) => new ErpErrorVerification(error, ctx))
    {
    }
}
