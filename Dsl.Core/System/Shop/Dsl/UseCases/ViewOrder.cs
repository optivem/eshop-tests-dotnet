using Driver.Api.Shop;
using Dsl.Core.Shop.Dsl.UseCases.Base;
using Dsl.Common;
using Driver.Api.Shop.Dtos;
using Driver.Api.Shop.Dtos.Error;

namespace Dsl.Core.Shop.Dsl.UseCases;

public class ViewOrder : BaseShopCommand<ViewOrderResponse, ViewOrderVerification>
{
    private string? _orderNumberResultAlias;

    public ViewOrder(IShopDriver driver, UseCaseContext context)
        : base(driver, context)
    {
    }

    public ViewOrder OrderNumber(string? orderNumberResultAlias)
    {
        _orderNumberResultAlias = orderNumberResultAlias;
        return this;
    }

    public override async Task<ShopUseCaseResult<ViewOrderResponse, ViewOrderVerification>> Execute()
    {
        var orderNumber = _context.GetResultValue(_orderNumberResultAlias);

        var result = await _driver.ViewOrderAsync(orderNumber);

        return new ShopUseCaseResult<ViewOrderResponse, ViewOrderVerification>(
            result,
            _context,
            (response, ctx) => new ViewOrderVerification(response, ctx));
    }
}



