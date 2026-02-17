using Optivem.EShop.SystemTest.Core.Tax.Driver.Dtos.Error;
using Commons.Util;
using Commons.Dsl;

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
