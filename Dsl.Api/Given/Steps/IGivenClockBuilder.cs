using Dsl.Api.Given.Steps.Base;

namespace Dsl.Api.Given.Steps;

public interface IGivenClockBuilder : IGivenStep
{
    IGivenClockBuilder WithTime(string? time);
}