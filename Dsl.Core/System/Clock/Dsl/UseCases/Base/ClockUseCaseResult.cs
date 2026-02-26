using Optivem.EShop.SystemTest.Driver.Api.Clock.Dtos;
using Common;
using Driver.Shared.Dsl;

namespace Optivem.EShop.SystemTest.Core.Clock.Dsl.UseCases.Base;

public class ClockUseCaseResult<TSuccessResponse, TSuccessVerification>
    : UseCaseResult<TSuccessResponse, ClockErrorResponse, TSuccessVerification, ClockErrorVerification>
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    public ClockUseCaseResult(
        Result<TSuccessResponse, ClockErrorResponse> result,
        UseCaseContext context,
        Func<TSuccessResponse, UseCaseContext, TSuccessVerification> verificationFactory)
        : base(result, context, verificationFactory, (error, ctx) => new ClockErrorVerification(error, ctx))
    {
    }
}
