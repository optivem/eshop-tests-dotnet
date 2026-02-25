using System.Runtime.CompilerServices;

namespace Dsl.Api.Then.Steps;

public interface IThenFailureVerifier
{
    IThenFailureVerifier ErrorMessage(string expectedMessage);

    IThenFailureVerifier FieldErrorMessage(string expectedField, string expectedMessage);

    IThenFailureAnd And();

    TaskAwaiter GetAwaiter();
}