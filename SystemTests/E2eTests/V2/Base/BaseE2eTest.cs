using Dsl.Common;
using ConfigEnvironment = Optivem.EShop.SystemTest.Configuration.Environment;
using Optivem.EShop.SystemTest.Configuration;
using Optivem.EShop.SystemTest.Base.V2;

namespace Optivem.EShop.SystemTest.E2eTests.V2.Base;

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
