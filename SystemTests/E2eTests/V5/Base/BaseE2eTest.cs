using Driver.Shared.Dsl;
using Optivem.EShop.SystemTest.Base.V5;

namespace Optivem.EShop.SystemTest.E2eTests.V5.Base;

public abstract class BaseE2eTest : BaseSystemDslTest
{
    protected override ExternalSystemMode? GetFixedExternalSystemMode()
    {
        return ExternalSystemMode.Real;
    }
}
