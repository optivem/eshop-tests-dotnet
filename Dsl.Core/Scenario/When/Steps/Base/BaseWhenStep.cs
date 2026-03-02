using Dsl.Core.Scenario.Then;
using Dsl.Port.Then;
using Dsl.Port.When.Steps.Base;
using Dsl.Common;
using Driver.Adapter;
using Optivem.Testing;

namespace Dsl.Core.Scenario.When;

public abstract class BaseWhen<TSuccessResponse, TSuccessVerification>
    : IWhenStep
    where TSuccessVerification : ResponseVerification<TSuccessResponse>
{
    private readonly AppDsl _app;
    private readonly ScenarioDsl _scenario;
    private readonly Func<Task> _ensureGiven;

    protected BaseWhen(AppDsl app, ScenarioDsl scenario, Func<Task> ensureGiven)
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

    protected abstract Task<ExecutionResult<TSuccessResponse, TSuccessVerification>> Execute(AppDsl app);

    protected Channel Channel => _scenario.Channel;
}


