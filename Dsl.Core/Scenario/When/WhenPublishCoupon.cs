using DslImpl.Scenario;
using DslImpl.Scenario.When;
using Dsl.Api.When.Steps;
using Driver.Shared.Dsl;
using Common;
using Optivem.EShop.SystemTest.Driver.Api.Shop.Dtos;
using Optivem.EShop.SystemTest.Core.Shop.Dsl.UseCases;
using Optivem.Testing;
using static Optivem.EShop.SystemTest.Core.Gherkin.GherkinDefaults;

namespace Optivem.EShop.SystemTest.Core.Gherkin.When;

public class PublishCoupon : BaseWhen<VoidValue, VoidVerification>, IPublishCoupon
{
    private string? _couponCode;
    private string? _discountRate;
    private string? _validFrom;
    private string? _validTo;
    private string? _usageLimit;

    public PublishCoupon(SystemDsl app, ScenarioDsl scenario, Func<Task> ensureGiven) : base(app, scenario, ensureGiven)
    {
        WithCouponCode(DefaultCouponCode);
        WithDiscountRate(DefaultDiscountRate);
    }

    public PublishCoupon WithCouponCode(string? couponCode)
    {
        _couponCode = couponCode;
        return this;
    }

    IPublishCoupon IPublishCoupon.WithCouponCode(string? couponCode) => WithCouponCode(couponCode);

    public PublishCoupon WithDiscountRate(string? discountRate)
    {
        _discountRate = discountRate;
        return this;
    }

    IPublishCoupon IPublishCoupon.WithDiscountRate(string? discountRate) => WithDiscountRate(discountRate);

    public PublishCoupon WithDiscountRate(decimal discountRate)
    {
        _discountRate = Converter.FromDecimal(discountRate);
        return this;
    }

    IPublishCoupon IPublishCoupon.WithDiscountRate(decimal discountRate) => WithDiscountRate(discountRate);

    public PublishCoupon WithValidFrom(string? validFrom)
    {
        _validFrom = validFrom;
        return this;
    }

    IPublishCoupon IPublishCoupon.WithValidFrom(string? validFrom) => WithValidFrom(validFrom);

    public PublishCoupon WithValidTo(string? validTo)
    {
        _validTo = validTo;
        return this;
    }

    IPublishCoupon IPublishCoupon.WithValidTo(string? validTo) => WithValidTo(validTo);

    public PublishCoupon WithUsageLimit(string? usageLimit)
    {
        _usageLimit = usageLimit;
        return this;
    }

    IPublishCoupon IPublishCoupon.WithUsageLimit(string? usageLimit) => WithUsageLimit(usageLimit);

    public PublishCoupon WithUsageLimit(int usageLimit)
    {
        _usageLimit = Converter.FromInteger(usageLimit);
        return this;
    }

    IPublishCoupon IPublishCoupon.WithUsageLimit(int usageLimit) => WithUsageLimit(usageLimit);

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
