using Optivem.EShop.SystemTest.Driver.Api.Clock.Dtos;
using Commons.Util;
using Driver.Core.Driver.Commons.Dsl;

namespace Optivem.EShop.SystemTest.Dsl.Clock.Dsl.UseCases.Base;

public class ClockDriver.Core.Driver.Commons.Dsl.UseCaseResult<TSuccessResponse, TSuccessVerification>
    : Driver.Core.Driver.Commons.Dsl.UseCaseResult<TSuccessResponse, ClockErrorResponse, TSuccessVerification, ClockErrorVerification>
    where TSuccessVerification : Driver.Core.Driver.Commons.Dsl.ResponseVerification<TSuccessResponse>
{
    public ClockDriver.Core.Driver.Commons.Dsl.UseCaseResult(
        Result<TSuccessResponse, ClockErrorResponse> result,
        Driver.Core.Driver.Commons.Dsl.UseCaseContext context,
        Func<TSuccessResponse, Driver.Core.Driver.Commons.Dsl.UseCaseContext, TSuccessVerification> verificationFactory)
        : base(result, context, verificationFactory, (error, ctx) => new ClockErrorVerification(error, ctx))
    {
    }
}
