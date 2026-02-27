using Dsl.Core.Scenario;
using Dsl.Core.Scenario.When;
using Dsl.Api.When.Steps;
using Driver.Core;
using Driver.Api.Shop.Dtos;
using Dsl.Core.Shop.Dsl.UseCases;
using Optivem.Testing;
using static Dsl.Core.Gherkin.GherkinDefaults;

namespace Dsl.Core.Scenario.When;

public class BrowseCoupons : BaseWhen<BrowseCouponsResponse, BrowseCouponsVerification>, IBrowseCoupons
{
    public BrowseCoupons(SystemDsl app, ScenarioDsl scenario, Func<Task> ensureGiven) : base(app, scenario, ensureGiven)
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



