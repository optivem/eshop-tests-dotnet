using Dsl.Port.Given;
using Dsl.Port.When;

namespace Dsl.Port.Given.Steps.Base;

public interface IGivenStep
{
    IGiven And();

    IWhen When();
}
