using Dsl.Core.Scenario.When;
using Dsl.Port.Given;
using Dsl.Port.Given.Steps.Base;
using Dsl.Port.When;
using Driver.Adapter;
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


