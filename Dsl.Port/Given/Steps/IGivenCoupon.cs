using Dsl.Api.Given.Steps.Base;

namespace Dsl.Api.Given.Steps;

public interface IGivenCoupon : IGivenStep
{
    IGivenCoupon WithCouponCode(string? couponCode);

    IGivenCoupon WithDiscountRate(string? discountRate);

    IGivenCoupon WithDiscountRate(decimal? discountRate);

    IGivenCoupon WithValidFrom(string? validFrom);

    IGivenCoupon WithValidTo(string? validTo);

    IGivenCoupon WithUsageLimit(string? usageLimit);

    IGivenCoupon WithUsageLimit(int? usageLimit);
}