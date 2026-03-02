using System.Runtime.CompilerServices;

namespace Dsl.Api.Then.Steps;

public interface IThenSuccess
{
    IThenSuccessAnd And();

    TaskAwaiter GetAwaiter();
}