using Dsl.Port;
using SystemTests.TestInfrastructure.Configuration;
using Dsl.Core;
using Optivem.Testing;
using Xunit;

namespace SystemTests.TestInfrastructure.Base.V6;

public abstract class BaseScenarioDslTest : BaseConfigurableTest, IAsyncLifetime
{
    private AppDsl _app = null!;

    public virtual async Task InitializeAsync()
    {
        var configuration = LoadConfiguration();
        _app = new AppDsl(configuration);
        await Task.CompletedTask;
    }

    protected IFeatureDsl Feature(Channel channel)
    {
        return new FeatureDsl(channel, _app);
    }

    protected IBackgroundDsl Background(Channel channel)
    {
        return Feature(channel).Background();
    }

    protected IScenarioDsl Scenario(Channel channel)
    {
        return Feature(channel).Scenario();
    }

    public virtual async Task DisposeAsync()
    {
        if (_app != null)
            await _app.DisposeAsync();
    }
}




