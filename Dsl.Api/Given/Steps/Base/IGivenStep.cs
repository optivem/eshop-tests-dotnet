using Dsl.Api.Given;
using Dsl.Api.When;

namespace Dsl.Api.Given.Steps.Base;

public interface IGivenStep
{
    IGivenClause And();

    IWhenClause When();
}