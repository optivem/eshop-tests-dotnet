using Dsl.Api.Given.Steps;
using Driver.Core;
using Driver.Core.Gherkin;
using static Driver.Core.Gherkin.GherkinDefaults;

namespace DslImpl.Scenario.Given;

public class GivenClock : BaseGiven, IGivenClock
{
    private string? _time;

    public GivenClock(GivenStage givenClause) : base(givenClause)
    {
        WithTime(DefaultTime);
    }

    public GivenClock WithTime(string? time)
    {
        _time = time;
        return this;
    }

    IGivenClock IGivenClock.WithTime(string? time) => WithTime(time);

    internal override async Task Execute(SystemDsl app)
    {
        (await app.Clock().ReturnsTime()
            .Time(_time)
            .Execute())
            .ShouldSucceed();
    }
}

