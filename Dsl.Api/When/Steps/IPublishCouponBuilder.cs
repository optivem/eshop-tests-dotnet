using Dsl.Api.When.Steps.Base;

namespace Dsl.Api.When.Steps;

public interface IPublishCouponBuilder : IWhenStep
{
    IPublishCouponBuilder WithCouponCode(string? couponCode);

    IPublishCouponBuilder WithDiscountRate(string? discountRate);

    IPublishCouponBuilder WithDiscountRate(decimal discountRate);

    IPublishCouponBuilder WithValidFrom(string? validFrom);

    IPublishCouponBuilder WithValidTo(string? validTo);

    IPublishCouponBuilder WithUsageLimit(string? usageLimit);

    IPublishCouponBuilder WithUsageLimit(int usageLimit);
}