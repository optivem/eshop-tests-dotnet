using Optivem.EShop.SystemTest.Driver.Api.Shop;
using Optivem.EShop.SystemTest.Dsl.Shop.Dsl.UseCases.Base;
using Optivem.EShop.SystemTest.Driver.Api.Shop.Dtos;
using Optivem.EShop.SystemTest.Driver.Api.Shop.Dtos.Error;
using Driver.Core.Driver.Commons.Dsl;
using Commons.Util;

namespace Optivem.EShop.SystemTest.Dsl.Shop.Dsl.UseCases;

public class PublishCoupon : BaseShopCommand<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>
{
    private string? _couponCodeParamAlias;
    private string? _discountRate;
    private string? _validFrom;
    private string? _validTo;
    private string? _usageLimit;

    public PublishCoupon(IShopDriver driver, Driver.Core.Driver.Commons.Dsl.UseCaseContext context)
        : base(driver, context)
    {
    }

    public PublishCoupon CouponCode(string? couponCodeParamAlias)
    {
        _couponCodeParamAlias = couponCodeParamAlias;
        return this;
    }

    public PublishCoupon DiscountRate(decimal discountRate)
    {
        _discountRate = discountRate.ToString();
        return this;
    }

    public PublishCoupon DiscountRate(string? discountRate)
    {
        _discountRate = discountRate;
        return this;
    }

    public PublishCoupon ValidFrom(string? validFrom)
    {
        _validFrom = validFrom;
        return this;
    }

    public PublishCoupon ValidTo(string? validTo)
    {
        _validTo = validTo;
        return this;
    }

    public PublishCoupon UsageLimit(string? usageLimit)
    {
        _usageLimit = usageLimit;
        return this;
    }

    public override async Task<ShopDriver.Core.Driver.Commons.Dsl.UseCaseResult<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>> Execute()
    {
        var couponCode = _context.GetParamValue(_couponCodeParamAlias);

        var request = new PublishCouponRequest
        {
            Code = couponCode,
            DiscountRate = _discountRate,
            ValidFrom = _validFrom,
            ValidTo = _validTo,
            UsageLimit = _usageLimit
        };

        var result = await _driver.PublishCouponAsync(request);

        return new ShopDriver.Core.Driver.Commons.Dsl.UseCaseResult<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>(
            result,
            _context,
            (response, ctx) => new Driver.Core.Driver.Commons.Dsl.VoidVerification(response, ctx));
    }
}
