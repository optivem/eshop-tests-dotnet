using Optivem.EShop.SystemTest.Driver.Api.Shop;
using Optivem.EShop.SystemTest.Dsl.Shop.Dsl.UseCases.Base;
using Optivem.EShop.SystemTest.Driver.Api.Shop.Dtos;
using Optivem.EShop.SystemTest.Driver.Api.Shop.Dtos.Error;
using Driver.Core.Driver.Commons.Dsl;

namespace Optivem.EShop.SystemTest.Dsl.Shop.Dsl.UseCases;

public class BrowseCoupons : BaseShopCommand<BrowseCouponsResponse, BrowseCouponsVerification>
{
    public BrowseCoupons(IShopDriver driver, Driver.Core.Driver.Commons.Dsl.UseCaseContext context)
        : base(driver, context)
    {
    }

    public override async Task<ShopDriver.Core.Driver.Commons.Dsl.UseCaseResult<BrowseCouponsResponse, BrowseCouponsVerification>> Execute()
    {
        var result = await _driver.BrowseCouponsAsync();

        return new ShopDriver.Core.Driver.Commons.Dsl.UseCaseResult<BrowseCouponsResponse, BrowseCouponsVerification>(
            result,
            _context,
            (response, ctx) => new BrowseCouponsVerification(response, ctx));
    }
}
