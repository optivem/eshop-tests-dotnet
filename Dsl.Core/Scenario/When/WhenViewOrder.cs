using Driver.Core;
using Dsl.Api.When.Steps;
using Driver.Api.Shop.Dtos;
using Driver.Core.Shop.Dsl.UseCases;
using Optivem.Testing;
using static Driver.Core.Gherkin.GherkinDefaults;

namespace DslImpl.Scenario.When;

public class ViewOrder : BaseWhen<ViewOrderResponse, ViewOrderVerification>, IViewOrder
{
    private string? _orderNumber;

    public ViewOrder(SystemDsl app, ScenarioDsl scenario, Func<Task> ensureGiven) : base(app, scenario, ensureGiven)
    {
        WithOrderNumber(DefaultOrderNumber);
    }

    public ViewOrder WithOrderNumber(string? orderNumber)
    {
        _orderNumber = orderNumber;
        return this;
    }

    IViewOrder IViewOrder.WithOrderNumber(string? orderNumber) => WithOrderNumber(orderNumber);

    protected override async Task<ExecutionResult<ViewOrderResponse, ViewOrderVerification>> Execute(SystemDsl app)
    {
        var shop = await app.Shop(Channel);
        var result = await shop.ViewOrder()
            .OrderNumber(_orderNumber)
            .Execute();

        return new ExecutionResultBuilder<ViewOrderResponse, ViewOrderVerification>(result)
            .OrderNumber(_orderNumber)
            .Build();
    }
}


