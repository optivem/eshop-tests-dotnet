using Optivem.EShop.SystemTest.Core.Shop.Driver.Dtos.Coupons;
using Optivem.EShop.SystemTest.Core.Shop.Driver.Dtos.Error;
using Commons.Util;

namespace Optivem.EShop.SystemTest.Core.Shop.Driver;

public interface ICouponDriver
{
    Task<Result<VoidValue, SystemError>> PublishCouponAsync(PublishCouponRequest request);
    Task<Result<BrowseCouponsResponse, SystemError>> BrowseCouponsAsync();
}