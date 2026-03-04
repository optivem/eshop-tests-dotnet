using Dsl.Port;
using Dsl.Common;
using ConfigEnvironment = SystemTests.TestInfrastructure.Configuration.Environment;
using SystemTests.TestInfrastructure.Configuration;
using SystemTests.TestInfrastructure.Base.V2;

namespace SystemTests.E2eTests.V2.Base;

public abstract class BaseE2eTest : BaseClientTest
{
    protected override ExternalSystemMode? GetFixedExternalSystemMode()
    {
        return ExternalSystemMode.Real;
    }

    public override async Task InitializeAsync()
    {
        await SetShopClientAsync();
        SetUpExternalClients();
    }

    protected abstract Task SetShopClientAsync();

    protected static string CreateUniqueSku(string baseSku)
    {
        var suffix = Guid.NewGuid().ToString("N")[..8];
        return $"{baseSku}-{suffix}";
    }
}



