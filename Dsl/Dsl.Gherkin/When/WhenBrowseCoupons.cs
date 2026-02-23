using Dsl.Gherkin;
using Dsl.Gherkin.When;
using Optivem.EShop.SystemTest.Core;
using Optivem.EShop.SystemTest.Core.Shop.Driver.Dtos.Coupons;
using Optivem.EShop.SystemTest.Core.Shop.Dsl.UseCases.Coupons;
using Optivem.Testing;
using static Optivem.EShop.SystemTest.Core.Gherkin.GherkinDefaults;

namespace Dsl.Gherkin.When;

public class BrowseCouponsBuilder : BaseWhenBuilder<BrowseCouponsResponse, BrowseCouponsVerification>
{
    public BrowseCouponsBuilder(SystemDsl app, ScenarioDsl scenario, Func<Task> ensureGiven) : base(app, scenario, ensureGiven)
    {
    }

    protected override async Task<ExecutionResult<BrowseCouponsResponse, BrowseCouponsVerification>> Execute(SystemDsl app)
    {
        var shop = await app.Shop(Channel);
        var result = await shop.BrowseCoupons()
            .Execute();

        return new ExecutionResultBuilder<BrowseCouponsResponse, BrowseCouponsVerification>(result)
            .Build();
    }
}