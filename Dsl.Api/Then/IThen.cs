using Dsl.Api.Then.Steps;

namespace Dsl.Api.Then;

public interface IThen
{
    IThenSuccessVerifier ShouldSucceed();

    IThenFailureVerifier ShouldFail();
}