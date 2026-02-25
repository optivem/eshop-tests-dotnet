using Optivem.EShop.SystemTest.Core;
using Dsl.Api.When.Steps;
using Optivem.EShop.SystemTest.Driver.Api.Shop.Dtos;
using Optivem.EShop.SystemTest.Core.Shop.Dsl.UseCases;
using Optivem.Testing;
using static Optivem.EShop.SystemTest.Core.Gherkin.GherkinDefaults;

namespace DslImpl.Gherkin.When;

public class ViewOrderBuilder : BaseWhenBuilder<ViewOrderResponse, ViewOrderVerification>, IViewOrderBuilder
{
    private string? _orderNumber;

    public ViewOrderBuilder(SystemDsl app, ScenarioDsl scenario, Func<Task> ensureGiven) : base(app, scenario, ensureGiven)
    {
        WithOrderNumber(DefaultOrderNumber);
    }

    public ViewOrderBuilder WithOrderNumber(string? orderNumber)
    {
        _orderNumber = orderNumber;
        return this;
    }

    IViewOrderBuilder IViewOrderBuilder.WithOrderNumber(string? orderNumber) => WithOrderNumber(orderNumber);

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
