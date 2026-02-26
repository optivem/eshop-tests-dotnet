using Dsl.Api.When.Steps.Base;

namespace Dsl.Api.When.Steps;

public interface ICancelOrder : IWhenStep
{
    ICancelOrder WithOrderNumber(string? orderNumber);
}