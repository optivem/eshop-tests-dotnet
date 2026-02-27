using Driver.Api.Erp.Dtos.Error;
using Common;
using Dsl.Common;

namespace Optivem.EShop.SystemTest.Core.Erp.Dsl.UseCases.Base;

public class ErpUseCaseResult<TSuccessResponse, TSuccessVerification>
    : UseCaseResult<TSuccessResponse, ErpErrorResponse, TSuccessVerification, ErpErrorVerification>
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    public ErpUseCaseResult(
        Result<TSuccessResponse, ErpErrorResponse> result,
        UseCaseContext context,
        Func<TSuccessResponse, UseCaseContext, TSuccessVerification> verificationFactory)
        : base(result, context, verificationFactory, (error, ctx) => new ErpErrorVerification(error, ctx))
    {
    }
}

