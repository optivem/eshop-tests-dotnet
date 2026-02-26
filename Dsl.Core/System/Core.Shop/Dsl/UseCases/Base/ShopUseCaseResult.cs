using Commons.Util;
using Driver.Shared.Dsl;
using Optivem.EShop.SystemTest.Driver.Api.Shop.Dtos.Error;

namespace Optivem.EShop.SystemTest.Core.Shop.Dsl.UseCases.Base;

public class ShopUseCaseResult<TSuccessResponse, TSuccessVerification>
    : UseCaseResult<TSuccessResponse, SystemError, TSuccessVerification, SystemErrorFailureVerification>
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    public ShopUseCaseResult(
        Result<TSuccessResponse, SystemError> result,
        UseCaseContext context,
        Func<TSuccessResponse, UseCaseContext, TSuccessVerification> verificationFactory)
        : base(result, context, verificationFactory, (error, ctx) => new SystemErrorFailureVerification(error, ctx))
    {
    }
}
