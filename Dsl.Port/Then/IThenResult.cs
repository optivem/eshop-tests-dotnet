using Dsl.Port.Then.Steps;

namespace Dsl.Port.Then;

public interface IThenResult : IThen
{
    IThenSuccess ShouldSucceed();

    IThenFailure ShouldFail();
}
