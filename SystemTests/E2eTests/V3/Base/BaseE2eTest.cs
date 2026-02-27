using Dsl.Common;
using SystemTests.TestInfrastructure.Base.V3;
using ConfigEnvironment = SystemTests.TestInfrastructure.Configuration.Environment;
using SystemTests.TestInfrastructure.Configuration;

namespace SystemTests.E2eTests.V3.Base;

public abstract class BaseE2eTest : BaseDriverTest
{
    protected override ExternalSystemMode? GetFixedExternalSystemMode()
    {
        return ExternalSystemMode.Real;
    }

    public override async Task InitializeAsync()
    {
        await SetShopDriverAsync();
        SetUpExternalDrivers();
    }

    protected abstract Task SetShopDriverAsync();

    protected static string CreateUniqueSku(string baseSku)
    {
        var suffix = Guid.NewGuid().ToString("N")[..8];
        return $"{baseSku}-{suffix}";
    }
}


