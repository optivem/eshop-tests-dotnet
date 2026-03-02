using Dsl.Port.Given;
using Dsl.Port.When;

namespace Dsl.Port;

public interface IScenarioDsl
{
    IGiven Given();

    IWhen When();
}
