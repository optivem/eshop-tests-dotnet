using DslImpl.Scenario.Then;
using Dsl.Api.Then;
using Dsl.Api.When.Steps.Base;
using Dsl.Common;
using Optivem.EShop.SystemTest.Core;
using Optivem.Testing;

namespace DslImpl.Scenario.When;

public abstract class BaseWhen<TSuccessResponse, TSuccessVerification>
    : IWhenStep
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    private readonly SystemDsl _app;
    private readonly ScenarioDsl _scenario;
    private readonly Func<Task> _ensureGiven;

    protected BaseWhen(SystemDsl app, ScenarioDsl scenario, Func<Task> ensureGiven)
    {
        _app = app;
        _scenario = scenario;
        _ensureGiven = ensureGiven;
    }

    public ThenStage<TSuccessResponse, TSuccessVerification> Then()
    {
        return new ThenStage<TSuccessResponse, TSuccessVerification>(Channel, _app, async () =>
        {
            await _ensureGiven();
            return await Execute(_app);
        });
    }

    IThen IWhenStep.Then() => Then();

    protected abstract Task<ExecutionResult<TSuccessResponse, TSuccessVerification>> Execute(SystemDsl app);

    protected Channel Channel => _scenario.Channel;
}
