using D;
using Optivem.EShop.SystemTest.Core.Shop.Dsl.UseCases.Base;
using D;
using D;
using Dsl.Common;

namespace Optivem.EShop.SystemTest.Core.Shop.Dsl.UseCases;

public class BrowseCoupons : BaseShopCommand<BrowseCouponsResponse, BrowseCouponsVerification>
{
    public BrowseCoupons(IShopDriver driver, UseCaseContext context)
        : base(driver, context)
    {
    }

    public override async Task<ShopUseCaseResult<BrowseCouponsResponse, BrowseCouponsVerification>> Execute()
    {
        var result = await _driver.BrowseCouponsAsync();

        return new ShopUseCaseResult<BrowseCouponsResponse, BrowseCouponsVerification>(
            result,
            _context,
            (response, ctx) => new BrowseCouponsVerification(response, ctx));
    }
}
