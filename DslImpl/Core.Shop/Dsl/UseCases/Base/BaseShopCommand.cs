using Optivem.EShop.SystemTest.Driver.Ports.Shop;
using Driver.Shared.Dsl;
using Optivem.EShop.SystemTest.Driver.Ports.Shop.Dtos.Error;

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
