using Driver.Api.Shop;
using Optivem.EShop.SystemTest.Core.Shop.Dsl.UseCases.Base;
using Driver.Api.Shop.Dtos.Error;
using Common;
using Dsl.Common;

namespace Optivem.EShop.SystemTest.Core.Shop.Dsl.UseCases;

public class GoToShop : BaseShopCommand<VoidValue, VoidVerification>
{
    public GoToShop(IShopDriver driver, UseCaseContext context)
        : base(driver, context)
    {
    }

    public override async Task<ShopUseCaseResult<VoidValue, VoidVerification>> Execute()
    {
        var result = await _driver.GoToShopAsync();

        return new ShopUseCaseResult<VoidValue, VoidVerification>(
            result,
            _context,
            (response, ctx) => new VoidVerification(response, ctx));
    }
}

