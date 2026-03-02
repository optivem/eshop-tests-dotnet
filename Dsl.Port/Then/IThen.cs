using Dsl.Port.Then.Steps;

namespace Dsl.Port.Then;

public interface IThen
{
    IThenSuccess ShouldSucceed();

    IThenFailure ShouldFail();
}
