using Commons.Dsl;
using Dsl.Gherkin;

namespace Dsl.Gherkin.Then;

public class ThenSuccessAssertionCoupon<TSuccessResponse, TSuccessVerification>
    : BaseThenAssertionCoupon<TSuccessResponse, TSuccessVerification, ThenSuccessAssertionCoupon<TSuccessResponse, TSuccessVerification>>
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    internal ThenSuccessAssertionCoupon(
        ThenClause<TSuccessResponse, TSuccessVerification> thenClause,
        Func<Task<string>> couponCodeFactory)
        : base(thenClause, couponCodeFactory)
    {
    }

    protected override Task RunPrelude(ExecutionResult<TSuccessResponse, TSuccessVerification> result)
    {
        _ = result.Result.ShouldSucceed();
        return Task.CompletedTask;
    }
}
