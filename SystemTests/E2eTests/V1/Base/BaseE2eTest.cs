using Driver.Shared.Dsl;
using ConfigEnvironment = Optivem.EShop.SystemTest.Configuration.Environment;
using Optivem.EShop.SystemTest.Configuration;
using Optivem.EShop.SystemTest.Base.V1;

namespace Optivem.EShop.SystemTest.E2eTests.V1.Base;

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
