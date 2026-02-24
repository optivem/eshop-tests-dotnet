using Driver.Shared.Dsl;
using Optivem.EShop.SystemTest.Base.V6;

namespace Optivem.EShop.SystemTest.E2eTests.V6.Base;

public abstract class BaseE2eTest : BaseScenarioDslTest
{
    protected override ExternalSystemMode? GetFixedExternalSystemMode()
    {
        return ExternalSystemMode.Real;
    }
}
