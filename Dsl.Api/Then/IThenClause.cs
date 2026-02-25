using Dsl.Api.Then.Steps;

namespace Dsl.Api.Then;

public interface IThenClause
{
    IThenSuccessVerifier ShouldSucceed();

    IThenFailureVerifier ShouldFail();
}