using Optivem.EShop.SystemTest.Driver.Api.Tax.Dtos.Error;
using Commons.Util;
using Driver.Core.Driver.Commons.Dsl;

namespace Optivem.EShop.SystemTest.Dsl.Tax.Dsl.UseCases.Base;

public class TaxDriver.Core.Driver.Commons.Dsl.UseCaseResult<TSuccessResponse, TSuccessVerification>
    : Driver.Core.Driver.Commons.Dsl.UseCaseResult<TSuccessResponse, TaxErrorResponse, TSuccessVerification, TaxErrorVerification>
    where TSuccessVerification : Driver.Core.Driver.Commons.Dsl.ResponseVerification<TSuccessResponse>
{
    public TaxDriver.Core.Driver.Commons.Dsl.UseCaseResult(
        Result<TSuccessResponse, TaxErrorResponse> result,
        Driver.Core.Driver.Commons.Dsl.UseCaseContext context,
        Func<TSuccessResponse, Driver.Core.Driver.Commons.Dsl.UseCaseContext, TSuccessVerification> verificationFactory)
        : base(result, context, verificationFactory, (error, ctx) => new TaxErrorVerification(error, ctx))
    {
    }
}
