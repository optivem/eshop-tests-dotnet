using DevLab.JmesPath.Functions;
using Dsl.Gherkin.When;
using Driver.Core.Driver.Commons.Dsl;
using Commons.Util;
using Optivem.EShop.SystemTest.Core;
using Optivem.EShop.SystemTest.Dsl.Gherkin;
using Optivem.EShop.SystemTest.Driver.Api.Shop.Dtos;
using Optivem.EShop.SystemTest.Dsl.Shop.Dsl.UseCases;
using Optivem.Testing;
using static Optivem.EShop.SystemTest.Core.Gherkin.GherkinDefaults;

namespace Dsl.Gherkin.Builders.When.CancelOrder;

public class CancelOrderBuilder : BaseWhenBuilder<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>
{
    private string? _orderNumber;

    public CancelOrderBuilder(SystemDsl app, ScenarioDsl scenario, Func<Task> ensureGiven) : base(app, scenario, ensureGiven)
    {
        WithOrderNumber(DefaultOrderNumber);
    }

    public CancelOrderBuilder WithOrderNumber(string? orderNumber)
    {
        _orderNumber = orderNumber;
        return this;
    }

    protected override async Task<ExecutionResult<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>> Execute(SystemDsl app)
    {
        var shop = await app.Shop(Channel);
        var result = await shop.CancelOrder()
            .OrderNumber(_orderNumber)
            .Execute();

        return new ExecutionResultBuilder<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>(result)
            .OrderNumber(_orderNumber)
            .Build();
    }
}
