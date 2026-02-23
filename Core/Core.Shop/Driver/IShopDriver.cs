using Commons.Util;
using Optivem.EShop.SystemTest.Core.Shop.Driver.Dtos.Error;

namespace Optivem.EShop.SystemTest.Core.Shop.Driver;

public interface IShopDriver : IAsyncDisposable
{
    Task<Result<VoidValue, SystemError>> GoToShopAsync();
    IOrderDriver Orders();
    ICouponDriver Coupons();
}
