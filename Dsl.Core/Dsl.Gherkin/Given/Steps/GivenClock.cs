using Dsl.Api.Given.Steps;
using Optivem.EShop.SystemTest.Core;
using Optivem.EShop.SystemTest.Core.Gherkin;
using static Optivem.EShop.SystemTest.Core.Gherkin.GherkinDefaults;

namespace DslImpl.Gherkin.Given;

public class GivenClockBuilder : BaseGivenBuilder, IGivenClockBuilder
{
    private string? _time;

    public GivenClockBuilder(GivenClause givenClause) : base(givenClause)
    {
        WithTime(DefaultTime);
    }

    public GivenClockBuilder WithTime(string? time)
    {
        _time = time;
        return this;
    }

    IGivenClockBuilder IGivenClockBuilder.WithTime(string? time) => WithTime(time);

    internal override async Task Execute(SystemDsl app)
    {
        (await app.Clock().ReturnsTime()
            .Time(_time)
            .Execute())
            .ShouldSucceed();
    }
}
