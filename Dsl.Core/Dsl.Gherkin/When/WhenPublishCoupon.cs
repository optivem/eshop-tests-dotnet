using DslImpl.Gherkin;
using DslImpl.Gherkin.When;
using Dsl.Api.When.Steps;
using Driver.Shared.Dsl;
using Commons.Util;
using Optivem.EShop.SystemTest.Driver.Api.Shop.Dtos;
using Optivem.EShop.SystemTest.Core.Shop.Dsl.UseCases;
using Optivem.Testing;
using static Optivem.EShop.SystemTest.Core.Gherkin.GherkinDefaults;

namespace Optivem.EShop.SystemTest.Core.Gherkin.When;

public class PublishCouponBuilder : BaseWhenBuilder<VoidValue, VoidVerification>, IPublishCouponBuilder
{
    private string? _couponCode;
    private string? _discountRate;
    private string? _validFrom;
    private string? _validTo;
    private string? _usageLimit;

    public PublishCouponBuilder(SystemDsl app, ScenarioDsl scenario, Func<Task> ensureGiven) : base(app, scenario, ensureGiven)
    {
        WithCouponCode(DefaultCouponCode);
        WithDiscountRate(DefaultDiscountRate);
    }

    public PublishCouponBuilder WithCouponCode(string? couponCode)
    {
        _couponCode = couponCode;
        return this;
    }

    IPublishCouponBuilder IPublishCouponBuilder.WithCouponCode(string? couponCode) => WithCouponCode(couponCode);

    public PublishCouponBuilder WithDiscountRate(string? discountRate)
    {
        _discountRate = discountRate;
        return this;
    }

    IPublishCouponBuilder IPublishCouponBuilder.WithDiscountRate(string? discountRate) => WithDiscountRate(discountRate);

    public PublishCouponBuilder WithDiscountRate(decimal discountRate)
    {
        _discountRate = Converter.FromDecimal(discountRate);
        return this;
    }

    IPublishCouponBuilder IPublishCouponBuilder.WithDiscountRate(decimal discountRate) => WithDiscountRate(discountRate);

    public PublishCouponBuilder WithValidFrom(string? validFrom)
    {
        _validFrom = validFrom;
        return this;
    }

    IPublishCouponBuilder IPublishCouponBuilder.WithValidFrom(string? validFrom) => WithValidFrom(validFrom);

    public PublishCouponBuilder WithValidTo(string? validTo)
    {
        _validTo = validTo;
        return this;
    }

    IPublishCouponBuilder IPublishCouponBuilder.WithValidTo(string? validTo) => WithValidTo(validTo);

    public PublishCouponBuilder WithUsageLimit(string? usageLimit)
    {
        _usageLimit = usageLimit;
        return this;
    }

    IPublishCouponBuilder IPublishCouponBuilder.WithUsageLimit(string? usageLimit) => WithUsageLimit(usageLimit);

    public PublishCouponBuilder WithUsageLimit(int usageLimit)
    {
        _usageLimit = Converter.FromInteger(usageLimit);
        return this;
    }

    IPublishCouponBuilder IPublishCouponBuilder.WithUsageLimit(int usageLimit) => WithUsageLimit(usageLimit);

    protected override async Task<ExecutionResult<VoidValue, VoidVerification>> Execute(SystemDsl app)
    {
        var shop = await app.Shop(Channel);
        var result = await shop.PublishCoupon()
            .CouponCode(_couponCode)
            .DiscountRate(_discountRate)
            .ValidFrom(_validFrom)
            .ValidTo(_validTo)
            .UsageLimit(_usageLimit)
            .Execute();

        return new ExecutionResultBuilder<VoidValue, VoidVerification>(result)
            .CouponCode(_couponCode)
            .Build();
    }
}
