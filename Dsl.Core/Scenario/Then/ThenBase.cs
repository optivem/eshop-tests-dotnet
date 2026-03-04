using Dsl.Port.Then;
using Optivem.Testing;

namespace Dsl.Core.Scenario.Then;

public class ThenStageBase : IThen
{
    protected readonly AppDsl _app;
    private readonly Func<Task>? _setup;
    private bool _setupCompleted;

    public ThenStageBase(AppDsl app, Func<Task>? setup = null)
    {
        _app = app;
        _setup = setup;
        _setupCompleted = false;
    }

    protected async Task EnsureSetup()
    {
        if (!_setupCompleted && _setup != null)
        {
            await _setup();
            _setupCompleted = true;
        }
    }
}
