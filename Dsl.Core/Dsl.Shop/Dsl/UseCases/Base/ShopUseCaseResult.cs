using Commons.Util;
using Driver.Core.Driver.Commons.Dsl;
using Optivem.EShop.SystemTest.Driver.Api.Shop.Dtos.Error;

namespace Optivem.EShop.SystemTest.Dsl.Shop.Dsl.UseCases.Base;

public class ShopDriver.Core.Driver.Commons.Dsl.UseCaseResult<TSuccessResponse, TSuccessVerification>
    : Driver.Core.Driver.Commons.Dsl.UseCaseResult<TSuccessResponse, SystemError, TSuccessVerification, SystemErrorFailureVerification>
    where TSuccessVerification : Driver.Core.Driver.Commons.Dsl.ResponseVerification<TSuccessResponse>
{
    public ShopDriver.Core.Driver.Commons.Dsl.UseCaseResult(
        Result<TSuccessResponse, SystemError> result,
        Driver.Core.Driver.Commons.Dsl.UseCaseContext context,
        Func<TSuccessResponse, Driver.Core.Driver.Commons.Dsl.UseCaseContext, TSuccessVerification> verificationFactory)
        : base(result, context, verificationFactory, (error, ctx) => new SystemErrorFailureVerification(error, ctx))
    {
    }
}
