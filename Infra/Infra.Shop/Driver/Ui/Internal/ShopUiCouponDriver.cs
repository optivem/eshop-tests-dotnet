using Commons.Util;
using Optivem.EShop.SystemTest.Infra.Shop.Client.Ui.Pages;
using Optivem.EShop.SystemTest.Core.Shop.Driver;
using Optivem.EShop.SystemTest.Core.Shop.Driver.Dtos.Coupons;
using Optivem.EShop.SystemTest.Core.Shop.Driver.Dtos.Error;
using Optivem.EShop.SystemTest.Core.Shop.Driver;
using static Optivem.EShop.SystemTest.Core.Shop.Driver.SystemResults;

namespace Optivem.EShop.SystemTest.Core.Shop.Driver.Ui.Internal;

public class ShopUiCouponDriver : ICouponDriver
{
    private const int MaxBrowseRetries = 10;
    private static readonly TimeSpan BrowseRetryDelay = TimeSpan.FromSeconds(1);

    private readonly Func<Task<HomePage>> _homePageSupplier;
    private readonly PageNavigator _pageNavigator;
    private CouponManagementPage? _couponManagementPage;

    public ShopUiCouponDriver(Func<Task<HomePage>> homePageSupplier, PageNavigator pageNavigator)
    {
        _homePageSupplier = homePageSupplier;
        _pageNavigator = pageNavigator;
    }

    public async Task<Result<VoidValue, SystemError>> PublishCouponAsync(PublishCouponRequest request)
    {
        await EnsureOnCouponManagementPageAsync();

        await _couponManagementPage!.InputCouponCodeAsync(request.Code);
        await _couponManagementPage.InputDiscountRateAsync(request.DiscountRate);
        await _couponManagementPage.InputValidFromAsync(request.ValidFrom);
        await _couponManagementPage.InputValidToAsync(request.ValidTo);
        await _couponManagementPage.InputUsageLimitAsync(request.UsageLimit);
        await _couponManagementPage.ClickPublishCouponAsync();

        var result = await _couponManagementPage.GetResultAsync();
        return result.MapVoid();
    }

    public async Task<Result<BrowseCouponsResponse, SystemError>> BrowseCouponsAsync()
    {
        // Retry with fresh page navigations to handle UI eventual consistency —
        // after publishing a coupon or placing an order, the coupon table
        // may not yet reflect the latest state on first load.
        for (int attempt = 0; attempt < MaxBrowseRetries; attempt++)
        {
            await NavigateToCouponManagementPageAsync();
            var coupons = await _couponManagementPage!.ReadCouponsAsync();

            if (coupons.Count > 0)
            {
                return Success(new BrowseCouponsResponse { Coupons = coupons });
            }

            await Task.Delay(BrowseRetryDelay);
        }

        // Final attempt — return whatever we get (even if empty)
        await NavigateToCouponManagementPageAsync();
        var finalCoupons = await _couponManagementPage!.ReadCouponsAsync();

        return Success(new BrowseCouponsResponse { Coupons = finalCoupons });
    }

    private async Task EnsureOnCouponManagementPageAsync()
    {
        if (!_pageNavigator.IsOnPage(PageNavigator.Page.COUPON_MANAGEMENT))
        {
            await NavigateToCouponManagementPageAsync();
        }
    }

    private async Task NavigateToCouponManagementPageAsync()
    {
        var homePage = await _homePageSupplier();
        _couponManagementPage = await homePage.ClickCouponManagementAsync();
        _pageNavigator.SetCurrentPage(PageNavigator.Page.COUPON_MANAGEMENT);
    }
}