using Dsl.Core.Scenario;
using Dsl.Port;
using SystemTests.TestInfrastructure.Configuration;
using Dsl.Core;
using Dsl.Core.Gherkin;
using Optivem.Testing;
using Xunit;

namespace SystemTests.TestInfrastructure.Base.V7;

public abstract class BaseScenarioDslTest : BaseConfigurableTest, IAsyncLifetime
{
    private SystemDsl _app = null!;
    private ScenarioDslFactory _scenarioFactory = null!;

    public virtual async Task InitializeAsync()
    {
        var configuration = LoadConfiguration();
        _app = new SystemDsl(configuration);
        _scenarioFactory = new ScenarioDslFactory(_app);
        await Task.CompletedTask;
    }

    protected IScenarioDsl Scenario(Channel channel)
    {
        return _scenarioFactory.Create(channel);
    }

    public virtual async Task DisposeAsync()
    {
        if (_app != null)
            await _app.DisposeAsync();
    }
}




