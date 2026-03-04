using Dsl.Port;
using Dsl.Common;
using SystemTests.TestInfrastructure.Base.V4;
using Dsl.Core.Shop;

namespace SystemTests.E2eTests.V4.Base;

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




