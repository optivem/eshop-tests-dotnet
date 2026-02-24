using Optivem.EShop.SystemTest.Driver.Api.Shop;
using Optivem.EShop.SystemTest.Dsl.Shop.Dsl.UseCases;
using Driver.Core.Driver.Commons.Dsl;

namespace Optivem.EShop.SystemTest.Dsl.Shop.Dsl;

public class ShopDsl : IAsyncDisposable
{
    private readonly IShopDriver _driver;
    private readonly Driver.Core.Driver.Commons.Dsl.UseCaseContext _context;

    private ShopDsl(IShopDriver driver, Driver.Core.Driver.Commons.Dsl.UseCaseContext context)
    {
        _driver = driver;
        _context = context;
    }

    public static Task<ShopDsl> CreateAsync(IShopDriver driver, Driver.Core.Driver.Commons.Dsl.UseCaseContext context)
    {
        return Task.FromResult(new ShopDsl(driver, context));
    }

    public async ValueTask DisposeAsync()
    {
        if (_driver != null)
            await _driver.DisposeAsync();
    }

    public GoToShop GoToShop() => new(_driver, _context);

    public PlaceOrder PlaceOrder() => new(_driver, _context);

    public CancelOrder CancelOrder() => new(_driver, _context);

    public ViewOrder ViewOrder() => new(_driver, _context);

    public BrowseCoupons BrowseCoupons() => new(_driver, _context);

    public PublishCoupon PublishCoupon() => new(_driver, _context);
}
