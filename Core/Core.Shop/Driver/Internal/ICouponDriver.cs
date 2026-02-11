using Optivem.EShop.SystemTest.Core.Shop.Commons.Dtos.Coupons;
using Optivem.EShop.SystemTest.Core.Shop.Commons.Dtos.Errors;
using Commons.Util;

namespace Optivem.EShop.SystemTest.Core.Shop.Driver.Internal;

public interface ICouponDriver
{
    Task<Result<VoidValue, SystemError>> PublishCouponAsync(PublishCouponRequest request);
    Task<Result<BrowseCouponsResponse, SystemError>> BrowseCouponsAsync();
}