using Optivem.EShop.SystemTest.Driver.Api.Shop;
using Optivem.EShop.SystemTest.Core.Shop.Dsl.UseCases.Base;
using Optivem.EShop.SystemTest.Driver.Api.Shop.Dtos;
using Optivem.EShop.SystemTest.Driver.Api.Shop.Dtos.Error;
using Driver.Shared.Dsl;
using Common;

namespace Optivem.EShop.SystemTest.Core.Shop.Dsl.UseCases;

public class PublishCoupon : BaseShopCommand<VoidValue, VoidVerification>
{
    private string? _couponCodeParamAlias;
    private string? _discountRate;
    private string? _validFrom;
    private string? _validTo;
    private string? _usageLimit;

    public PublishCoupon(IShopDriver driver, UseCaseContext context)
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

    public override async Task<ShopUseCaseResult<VoidValue, VoidVerification>> Execute()
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

        return new ShopUseCaseResult<VoidValue, VoidVerification>(
            result,
            _context,
            (response, ctx) => new VoidVerification(response, ctx));
    }
}
