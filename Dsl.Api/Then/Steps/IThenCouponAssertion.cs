namespace Dsl.Api.Then.Steps;

public interface IThenCouponAssertion
{
    IThenCouponAssertion HasDiscountRate(decimal discountRate);

    IThenCouponAssertion IsValidFrom(string validFrom);

    IThenCouponAssertion IsValidTo(string validTo);

    IThenCouponAssertion HasUsageLimit(int usageLimit);

    IThenCouponAssertion HasUsedCount(int expectedUsedCount);
}