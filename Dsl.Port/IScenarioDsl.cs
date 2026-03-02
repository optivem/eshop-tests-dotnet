using Dsl.Api.Given;
using Dsl.Api.When;

namespace Dsl.Api;

public interface IScenarioDsl
{
    IGiven Given();

    IWhen When();
}