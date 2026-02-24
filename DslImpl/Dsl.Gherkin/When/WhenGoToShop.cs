using DslImpl.Gherkin;
using DslImpl.Gherkin.When;
using Commons.Dsl;
using Commons.Util;
using Optivem.EShop.SystemTest.Core;

namespace DslImpl.Gherkin.When;

public class GoToShopBuilder : BaseWhenBuilder<VoidValue, VoidVerification>
{
    public GoToShopBuilder(SystemDsl app, ScenarioDsl scenario, Func<Task> ensureGiven) : base(app, scenario, ensureGiven)
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
