using DevLab.JmesPath.Functions;
using DslImpl.Scenario.When;
using Dsl.Api.When.Steps;
using Dsl.Common;
using Common;
using Optivem.EShop.SystemTest.Core;
using Optivem.EShop.SystemTest.Core.Gherkin;
using Driver.Api.Shop.Dtos;
using Optivem.EShop.SystemTest.Core.Shop.Dsl.UseCases;
using Optivem.Testing;
using static Optivem.EShop.SystemTest.Core.Gherkin.GherkinDefaults;

namespace DslImpl.Scenario.Builders.When.CancelOrder;

public class CancelOrder : BaseWhen<VoidValue, VoidVerification>, ICancelOrder
{
    private string? _orderNumber;

    public CancelOrder(SystemDsl app, ScenarioDsl scenario, Func<Task> ensureGiven) : base(app, scenario, ensureGiven)
    {
        WithOrderNumber(DefaultOrderNumber);
    }

    public CancelOrder WithOrderNumber(string? orderNumber)
    {
        _orderNumber = orderNumber;
        return this;
    }

    ICancelOrder ICancelOrder.WithOrderNumber(string? orderNumber) => WithOrderNumber(orderNumber);

    protected override async Task<ExecutionResult<VoidValue, VoidVerification>> Execute(SystemDsl app)
    {
        var shop = await app.Shop(Channel);
        var result = await shop.CancelOrder()
            .OrderNumber(_orderNumber)
            .Execute();

        return new ExecutionResultBuilder<VoidValue, VoidVerification>(result)
            .OrderNumber(_orderNumber)
            .Build();
    }
}

