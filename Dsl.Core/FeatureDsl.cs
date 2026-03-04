using Dsl.Core.Scenario;
using Dsl.Port;
using Optivem.Testing;

namespace Dsl.Core;

public class FeatureDsl : IFeatureDsl
{
    private readonly AppDsl _app;
    private readonly Channel? _channel;

    public FeatureDsl(AppDsl app, Channel? channel = null)
    {
        _app = app;
        _channel = channel;
    }

    public IBackgroundDsl Background()
    {
        return new BackgroundDsl(_app, _channel);
    }

    public IScenarioDsl Scenario()
    {
        return new Scenario.ScenarioDsl(_channel!, _app);
    }
}
