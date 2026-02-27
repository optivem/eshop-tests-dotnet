using Optivem.EShop.SystemTest.Driver.Api.Tax.Dtos.Error;
using Common;
using Dsl.Common;

namespace Optivem.EShop.SystemTest.Core.Tax.Dsl.UseCases.Base;

public class TaxUseCaseResult<TSuccessResponse, TSuccessVerification>
    : UseCaseResult<TSuccessResponse, TaxErrorResponse, TSuccessVerification, TaxErrorVerification>
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    public TaxUseCaseResult(
        Result<TSuccessResponse, TaxErrorResponse> result,
        UseCaseContext context,
        Func<TSuccessResponse, UseCaseContext, TSuccessVerification> verificationFactory)
        : base(result, context, verificationFactory, (error, ctx) => new TaxErrorVerification(error, ctx))
    {
    }
}
