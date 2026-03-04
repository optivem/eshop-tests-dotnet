using Dsl.Core.Scenario;
using Dsl.Core.Scenario.When.Steps.Base;
using Dsl.Port.When.Steps;
using Dsl.Common;
using Common;
using Driver.Adapter;

namespace Dsl.Core.Scenario.When.Steps;

public class GoToShop : BaseWhen<VoidValue, VoidVerification>, IGoToShop
{
    public GoToShop(AppDsl app, ScenarioDsl scenario, Func<Task> ensureGiven) : base(app, scenario, ensureGiven)
    {
    }

    protected override async Task<ExecutionResult<VoidValue, VoidVerification>> Execute(AppDsl app)
    {
        var shop = await app.Shop(Channel);
        var result = await shop.GoToShop()
            .Execute();

        return new ExecutionResultBuilder<VoidValue, VoidVerification>(result)
            .Build();
    }
}


