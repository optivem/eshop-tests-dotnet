using Optivem.EShop.SystemTest.Driver.Api.Shop;
using Optivem.EShop.SystemTest.Dsl.Shop.Dsl.UseCases.Base;
using Optivem.EShop.SystemTest.Driver.Api.Shop.Dtos.Error;
using Commons.Util;
using Driver.Core.Driver.Commons.Dsl;

namespace Optivem.EShop.SystemTest.Dsl.Shop.Dsl.UseCases;

public class GoToShop : BaseShopCommand<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>
{
    public GoToShop(IShopDriver driver, Driver.Core.Driver.Commons.Dsl.UseCaseContext context)
        : base(driver, context)
    {
    }

    public override async Task<ShopDriver.Core.Driver.Commons.Dsl.UseCaseResult<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>> Execute()
    {
        var result = await _driver.GoToShopAsync();

        return new ShopDriver.Core.Driver.Commons.Dsl.UseCaseResult<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>(
            result,
            _context,
            (response, ctx) => new Driver.Core.Driver.Commons.Dsl.VoidVerification(response, ctx));
    }
}
