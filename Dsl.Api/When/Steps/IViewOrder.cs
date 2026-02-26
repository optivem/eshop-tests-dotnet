using Dsl.Api.When.Steps.Base;

namespace Dsl.Api.When.Steps;

public interface IViewOrder : IWhenStep
{
    IViewOrder WithOrderNumber(string? orderNumber);
}