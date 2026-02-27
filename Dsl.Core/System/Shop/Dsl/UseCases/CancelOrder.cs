using Driver.Api.Shop;
using Optivem.EShop.SystemTest.Core.Shop.Dsl.UseCases.Base;
using Driver.Api.Shop.Dtos.Error;
using Common;
using Dsl.Common;

namespace Optivem.EShop.SystemTest.Core.Shop.Dsl.UseCases;

public class CancelOrder : BaseShopCommand<VoidValue, VoidVerification>
{
    private string? _orderNumberResultAlias;

    public CancelOrder(IShopDriver driver, UseCaseContext context)
        : base(driver, context)
    {
    }

    public CancelOrder OrderNumber(string? orderNumberResultAlias)
    {
        _orderNumberResultAlias = orderNumberResultAlias;
        return this;
    }

    public override async Task<ShopUseCaseResult<VoidValue, VoidVerification>> Execute()
    {
        var orderNumber = _context.GetResultValue(_orderNumberResultAlias);
        var result = await _driver.CancelOrderAsync(orderNumber);

        return new ShopUseCaseResult<VoidValue, VoidVerification>(
            result,
            _context,
            (response, ctx) => new VoidVerification(response, ctx));
    }
}

