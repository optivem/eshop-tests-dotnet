using Optivem.EShop.SystemTest.Driver.Api.Shop;
using Driver.Core.Driver.Commons.Dsl;
using Optivem.EShop.SystemTest.Driver.Api.Shop.Dtos.Error;

namespace Optivem.EShop.SystemTest.Dsl.Shop.Dsl.UseCases.Base;

public abstract class BaseShopCommand<TResponse, TVerification>
    where TVerification : Driver.Core.Driver.Commons.Dsl.ResponseVerification<TResponse>
{
    protected readonly IShopDriver _driver;
    protected readonly Driver.Core.Driver.Commons.Dsl.UseCaseContext _context;

    protected BaseShopCommand(IShopDriver driver, Driver.Core.Driver.Commons.Dsl.UseCaseContext context)
    {
        _driver = driver;
        _context = context;
    }

    public abstract Task<ShopDriver.Core.Driver.Commons.Dsl.UseCaseResult<TResponse, TVerification>> Execute();
}
