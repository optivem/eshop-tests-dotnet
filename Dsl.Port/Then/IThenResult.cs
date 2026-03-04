using Dsl.Port.Then.Steps;

namespace Dsl.Port.Then;

public interface IThenResult
{
    IThenSuccess ShouldSucceed();

    IThenFailure ShouldFail();
}
