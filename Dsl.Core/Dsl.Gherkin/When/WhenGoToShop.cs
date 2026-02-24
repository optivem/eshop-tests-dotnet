using Dsl.Gherkin;
using Dsl.Gherkin.When;
using Driver.Core.Driver.Commons.Dsl;
using Commons.Util;
using Optivem.EShop.SystemTest.Core;

namespace Dsl.Gherkin.When;

public class GoToShopBuilder : BaseWhenBuilder<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>
{
    public GoToShopBuilder(SystemDsl app, ScenarioDsl scenario, Func<Task> ensureGiven) : base(app, scenario, ensureGiven)
    {
    }

    protected override async Task<ExecutionResult<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>> Execute(SystemDsl app)
    {
        var shop = await app.Shop(Channel);
        var result = await shop.GoToShop()
            .Execute();

        return new ExecutionResultBuilder<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>(result)
            .Build();
    }
}
