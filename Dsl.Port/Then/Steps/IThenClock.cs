namespace Dsl.Port.Then.Steps;

public interface IThenClock
{
    IThenClock HasTime(string time);

    IThenClock HasTime();
}
