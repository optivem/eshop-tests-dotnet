using Dsl.Core.Scenario.When;
using Dsl.Api.Given;
using Dsl.Api.Given.Steps.Base;
using Dsl.Api.When;
using Driver.Core;
using Optivem.Testing;

namespace Dsl.Core.Scenario.Given;

public abstract class BaseGiven : IGivenStep
{
    private readonly GivenStage _givenClause;

    protected BaseGiven(GivenStage givenClause)
    {
        _givenClause = givenClause;
    }

    public GivenStage And()
    {
        return _givenClause;
    }

    IGiven IGivenStep.And() => And();

    public WhenStage When()
    {
        return _givenClause.When();
    }

    IWhen IGivenStep.When() => When();

    internal abstract Task Execute(SystemDsl app);

    protected Channel Channel => _givenClause.Channel;
}


