using Dsl.Api.Given.Steps.Base;

namespace Dsl.Api.Given.Steps;

public interface IGivenClock : IGivenStep
{
    IGivenClock WithTime(string? time);
}