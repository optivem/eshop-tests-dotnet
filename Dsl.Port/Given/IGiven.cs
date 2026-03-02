using Dsl.Api.Given.Steps;
using Dsl.Api.When;

namespace Dsl.Api.Given;

public interface IGiven
{
    IGivenProduct Product();

    IGivenOrder Order();

    IGivenClock Clock();

    IGivenCountry Country();

    IGivenCoupon Coupon();

    IWhen When();
}