using System.Runtime.CompilerServices;

namespace Dsl.Api.Then.Steps;

public interface IThenFailure
{
    IThenFailure ErrorMessage(string expectedMessage);

    IThenFailure FieldErrorMessage(string expectedField, string expectedMessage);

    IThenFailureAnd And();

    TaskAwaiter GetAwaiter();
}