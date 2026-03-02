using Dsl.Api.Then.Steps;

namespace Dsl.Api.Then;

public interface IThen
{
    IThenSuccess ShouldSucceed();

    IThenFailure ShouldFail();
}