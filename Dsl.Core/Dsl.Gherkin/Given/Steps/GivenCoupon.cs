using Commons.Util;
using Dsl.Api.Given.Steps;
using DslImpl.Gherkin.Given;
using static Optivem.EShop.SystemTest.Core.Gherkin.GherkinDefaults;

namespace Optivem.EShop.SystemTest.Core.Gherkin.Given;

public class GivenCouponBuilder : BaseGivenBuilder, IGivenCouponBuilder
{
    private string? _couponCode;
    private string? _discountRate;
    private string? _validFrom;
    private string? _validTo;
    private string? _usageLimit;

    public GivenCouponBuilder(GivenClause givenClause) : base(givenClause)
    {
        WithCouponCode(DefaultCouponCode);
        WithDiscountRate(DefaultDiscountRate);
        WithValidFrom(Empty);
        WithValidTo(Empty);
        WithUsageLimit(Empty);
    }

    public GivenCouponBuilder WithCouponCode(string? couponCode)
    {
        _couponCode = couponCode;
        return this;
    }

    IGivenCouponBuilder IGivenCouponBuilder.WithCouponCode(string? couponCode) => WithCouponCode(couponCode);

    public GivenCouponBuilder WithDiscountRate(string? discountRate)
    {
        _discountRate = discountRate;
        return this;
    }

    IGivenCouponBuilder IGivenCouponBuilder.WithDiscountRate(string? discountRate) => WithDiscountRate(discountRate);

    public GivenCouponBuilder WithDiscountRate(decimal? discountRate)
    {
        _discountRate = Converter.FromDecimal(discountRate);
        return this;
    }

    IGivenCouponBuilder IGivenCouponBuilder.WithDiscountRate(decimal? discountRate) => WithDiscountRate(discountRate);


    public GivenCouponBuilder WithValidFrom(string? validFrom)
    {
        _validFrom = validFrom;
        return this;
    }

    IGivenCouponBuilder IGivenCouponBuilder.WithValidFrom(string? validFrom) => WithValidFrom(validFrom);

    public GivenCouponBuilder WithValidTo(string? validTo)
    {
        _validTo = validTo;
        return this;
    }

    IGivenCouponBuilder IGivenCouponBuilder.WithValidTo(string? validTo) => WithValidTo(validTo);

    public GivenCouponBuilder WithUsageLimit(string? usageLimit)
    {
        _usageLimit = usageLimit;
        return this;
    }

    IGivenCouponBuilder IGivenCouponBuilder.WithUsageLimit(string? usageLimit) => WithUsageLimit(usageLimit);

    public GivenCouponBuilder WithUsageLimit(int? usageLimit)
    {
        return WithUsageLimit(Converter.FromInteger(usageLimit));
    }

    IGivenCouponBuilder IGivenCouponBuilder.WithUsageLimit(int? usageLimit) => WithUsageLimit(usageLimit);

    internal override async Task Execute(SystemDsl app)
    {
        var shop = await app.Shop(Channel);
        (await shop.PublishCoupon()
            .CouponCode(_couponCode)
            .DiscountRate(_discountRate)
            .ValidFrom(_validFrom)
            .ValidTo(_validTo)
            .UsageLimit(_usageLimit)
            .Execute())
            .ShouldSucceed();
    }
}
