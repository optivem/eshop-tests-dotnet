using Dsl.Api.When.Steps.Base;

namespace Dsl.Api.When.Steps;

public interface ICancelOrderBuilder : IWhenStep
{
    ICancelOrderBuilder WithOrderNumber(string? orderNumber);
}