using Dsl.Api.When.Steps.Base;

namespace Dsl.Api.When.Steps;

public interface IViewOrderBuilder : IWhenStep
{
    IViewOrderBuilder WithOrderNumber(string? orderNumber);
}