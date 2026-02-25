using DslImpl.Gherkin.Then;
using Dsl.Api.Then;
using Dsl.Api.When.Steps.Base;
using Driver.Shared.Dsl;
using Optivem.EShop.SystemTest.Core;
using Optivem.Testing;

namespace DslImpl.Gherkin.When;

public abstract class BaseWhenBuilder<TSuccessResponse, TSuccessVerification>
    : IWhenStep
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    private readonly SystemDsl _app;
    private readonly ScenarioDsl _scenario;
    private readonly Func<Task> _ensureGiven;

    protected BaseWhenBuilder(SystemDsl app, ScenarioDsl scenario, Func<Task> ensureGiven)
    {
        _app = app;
        _scenario = scenario;
        _ensureGiven = ensureGiven;
    }

    public ThenClause<TSuccessResponse, TSuccessVerification> Then()
    {
        return new ThenClause<TSuccessResponse, TSuccessVerification>(Channel, _app, async () =>
        {
            await _ensureGiven();
            return await Execute(_app);
        });
    }

    IThenClause IWhenStep.Then() => Then();

    protected abstract Task<ExecutionResult<TSuccessResponse, TSuccessVerification>> Execute(SystemDsl app);

    protected Channel Channel => _scenario.Channel;
}
