using Dsl.Api.Given.Steps;
using Dsl.Api.When;

namespace Dsl.Api.Given;

public interface IGivenClause
{
    IGivenProductBuilder Product();

    IGivenOrderBuilder Order();

    IGivenClockBuilder Clock();

    IGivenCountryBuilder Country();

    IGivenCouponBuilder Coupon();

    IWhenClause When();
}