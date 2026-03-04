using Dsl.Core.Clock.UseCases;
using Dsl.Port.Then.Steps;

namespace Dsl.Core.Scenario.Then.Steps;

public class ThenClock : IThenClock
{
    private readonly GetTimeVerification _verification;

    public ThenClock(GetTimeVerification verification)
    {
        _verification = verification;
    }

    public IThenClock HasTime(string time)
    {
        _verification.Time(time);
        return this;
    }

    public IThenClock HasTime()
    {
        _verification.TimeIsNotNull();
        return this;
    }
}
