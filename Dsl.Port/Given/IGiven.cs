using Dsl.Port.Given.Steps;
using Dsl.Port.Then;
using Dsl.Port.When;

namespace Dsl.Port.Given;

public interface IGiven
{
    IGivenProduct Product();

    IGivenOrder Order();

    IGivenClock Clock();

    IGivenCountry Country();

    IGivenCoupon Coupon();

    IWhen When();

    IThen Then();
}
