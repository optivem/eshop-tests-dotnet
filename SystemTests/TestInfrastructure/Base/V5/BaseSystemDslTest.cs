using SystemTests.TestInfrastructure.Configuration;
using Dsl.Core;
using Xunit;

namespace SystemTests.TestInfrastructure.Base.V5;

public abstract class BaseSystemDslTest : BaseConfigurableTest, IAsyncLifetime
{
    protected SystemDsl _app = null!;

    public virtual async Task InitializeAsync()
    {
        var configuration = LoadConfiguration();
        _app = new SystemDsl(configuration);
        await Task.CompletedTask;
    }

    public virtual async Task DisposeAsync()
    {
        if (_app != null)
            await _app.DisposeAsync();
    }
}



