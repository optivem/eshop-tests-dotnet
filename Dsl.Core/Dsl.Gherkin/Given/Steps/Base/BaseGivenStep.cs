using DslImpl.Gherkin.When;
using Dsl.Api.Given;
using Dsl.Api.Given.Steps.Base;
using Dsl.Api.When;
using Optivem.EShop.SystemTest.Core;
using Optivem.Testing;

namespace DslImpl.Gherkin.Given;

public abstract class BaseGivenBuilder : IGivenStep
{
    private readonly GivenStage _givenClause;

    protected BaseGivenBuilder(GivenStage givenClause)
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
