using Commons.Dsl;

namespace Dsl.Gherkin.Then;

/// <summary>
/// Base for state verification builders (order/coupon). Aligns with Java BaseThenStateBuilder.
/// </summary>
public abstract class BaseThenStateBuilder<TSuccessResponse, TSuccessVerification>
    : BaseThenBuilder<TSuccessResponse, TSuccessVerification>
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    protected BaseThenStateBuilder(ThenClause<TSuccessResponse, TSuccessVerification> thenClause)
        : base(thenClause)
    {
    }
}
