using Driver.Impl.Commons.Dsl;
using Optivem.EShop.SystemTest.Base.V4;
using Optivem.EShop.SystemTest.Core.Shop;

namespace Optivem.EShop.SystemTest.E2eTests.V4.Base;

public abstract class BaseE2eTest : BaseChannelDriverTest
{
    protected override ExternalSystemMode? GetFixedExternalSystemMode()
    {
        return ExternalSystemMode.Real;
    }

    protected static string CreateUniqueSku(string baseSku)
    {
        var suffix = Guid.NewGuid().ToString("N")[..8];
        return $"{baseSku}-{suffix}";
    }
}
