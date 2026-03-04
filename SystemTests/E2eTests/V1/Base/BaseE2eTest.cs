using Dsl.Port;
using Dsl.Common;
using ConfigEnvironment = SystemTests.TestInfrastructure.Configuration.Environment;
using SystemTests.TestInfrastructure.Configuration;
using SystemTests.TestInfrastructure.Base.V1;

namespace SystemTests.E2eTests.V1.Base;

public abstract class BaseE2eTest : BaseRawTest
{
    protected override ExternalSystemMode? GetFixedExternalSystemMode()
    {
        return ExternalSystemMode.Real;
    }

    public override async Task InitializeAsync()
    {
        await SetShopRawAsync();
        SetUpExternalHttpClients();
    }

    protected abstract Task SetShopRawAsync();

    protected static string CreateUniqueSku(string baseSku)
    {
        var suffix = Guid.NewGuid().ToString("N")[..8];
        return $"{baseSku}-{suffix}";
    }
}



