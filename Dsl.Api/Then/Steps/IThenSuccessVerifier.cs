using System.Runtime.CompilerServices;

namespace Dsl.Api.Then.Steps;

public interface IThenSuccessVerifier
{
    IThenSuccessAnd And();

    TaskAwaiter GetAwaiter();
}