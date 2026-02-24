using Optivem.EShop.SystemTest.Driver.Api.Shop;
using Optivem.EShop.SystemTest.Dsl.Shop.Dsl.UseCases.Base;
using Driver.Core.Driver.Commons.Dsl;
using Optivem.EShop.SystemTest.Driver.Api.Shop.Dtos;
using Optivem.EShop.SystemTest.Driver.Api.Shop.Dtos.Error;

namespace Optivem.EShop.SystemTest.Dsl.Shop.Dsl.UseCases;

public class ViewOrder : BaseShopCommand<ViewOrderResponse, ViewOrderVerification>
{
    private string? _orderNumberResultAlias;

    public ViewOrder(IShopDriver driver, Driver.Core.Driver.Commons.Dsl.UseCaseContext context)
        : base(driver, context)
    {
    }

    public ViewOrder OrderNumber(string? orderNumberResultAlias)
    {
        _orderNumberResultAlias = orderNumberResultAlias;
        return this;
    }

    public override async Task<ShopDriver.Core.Driver.Commons.Dsl.UseCaseResult<ViewOrderResponse, ViewOrderVerification>> Execute()
    {
        var orderNumber = _context.GetResultValue(_orderNumberResultAlias);

        var result = await _driver.ViewOrderAsync(orderNumber);

        return new ShopDriver.Core.Driver.Commons.Dsl.UseCaseResult<ViewOrderResponse, ViewOrderVerification>(
            result,
            _context,
            (response, ctx) => new ViewOrderVerification(response, ctx));
    }
}
