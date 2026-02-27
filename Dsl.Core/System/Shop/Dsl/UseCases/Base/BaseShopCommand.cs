using Optivem.EShop.SystemTest.Driver.Api.Shop;
using Dsl.Common;
using Optivem.EShop.SystemTest.Driver.Api.Shop.Dtos.Error;

namespace Optivem.EShop.SystemTest.Core.Shop.Dsl.UseCases.Base;

public abstract class BaseShopCommand<TResponse, TVerification>
    where TVerification : ResponseVerification<TResponse>
{
    protected readonly IShopDriver _driver;
    protected readonly UseCaseContext _context;

    protected BaseShopCommand(IShopDriver driver, UseCaseContext context)
    {
        _driver = driver;
        _context = context;
    }

    public abstract Task<ShopUseCaseResult<TResponse, TVerification>> Execute();
}
