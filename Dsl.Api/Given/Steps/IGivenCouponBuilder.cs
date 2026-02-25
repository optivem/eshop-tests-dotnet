using Dsl.Api.Given.Steps.Base;

namespace Dsl.Api.Given.Steps;

public interface IGivenCouponBuilder : IGivenStep
{
    IGivenCouponBuilder WithCouponCode(string? couponCode);

    IGivenCouponBuilder WithDiscountRate(string? discountRate);

    IGivenCouponBuilder WithDiscountRate(decimal? discountRate);

    IGivenCouponBuilder WithValidFrom(string? validFrom);

    IGivenCouponBuilder WithValidTo(string? validTo);

    IGivenCouponBuilder WithUsageLimit(string? usageLimit);

    IGivenCouponBuilder WithUsageLimit(int? usageLimit);
}