using DslImpl.Gherkin.When;
using Dsl.Api.Given;
using Dsl.Api.Given.Steps.Base;
using Dsl.Api.When;
using Optivem.EShop.SystemTest.Core;
using Optivem.Testing;

namespace DslImpl.Gherkin.Given;

public abstract class BaseGivenBuilder : IGivenStep
{
    private readonly GivenClause _givenClause;

    protected BaseGivenBuilder(GivenClause givenClause)
    {
        _givenClause = givenClause;
    }

    public GivenClause And()
    {
        return _givenClause;
    }

    IGivenClause IGivenStep.And() => And();

    public WhenClause When()
    {
        return _givenClause.When();
    }

    IWhenClause IGivenStep.When() => When();

    internal abstract Task Execute(SystemDsl app);

    protected Channel Channel => _givenClause.Channel;
}
