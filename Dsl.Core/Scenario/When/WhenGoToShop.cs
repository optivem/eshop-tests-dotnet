using DslImpl.Scenario;
using DslImpl.Scenario.When;
using Dsl.Api.When.Steps;
using Dsl.Common;
using Common;
using Driver.Core;

namespace DslImpl.Scenario.When;

public class GoToShop : BaseWhen<VoidValue, VoidVerification>, IGoToShop
{
    public GoToShop(SystemDsl app, ScenarioDsl scenario, Func<Task> ensureGiven) : base(app, scenario, ensureGiven)
    {
    }

    protected override async Task<ExecutionResult<VoidValue, VoidVerification>> Execute(SystemDsl app)
    {
        var shop = await app.Shop(Channel);
        var result = await shop.GoToShop()
            .Execute();

        return new ExecutionResultBuilder<VoidValue, VoidVerification>(result)
            .Build();
    }
}

