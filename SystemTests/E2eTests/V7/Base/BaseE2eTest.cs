using Dsl.Common;
using SystemTests.TestInfrastructure.Base.V7;

namespace Optivem.EShop.SystemTest.E2eTests.V7.Base;

public abstract class BaseE2eTest : BaseScenarioDslTest
{
    protected override ExternalSystemMode? GetFixedExternalSystemMode()
    {
        return ExternalSystemMode.Real;
    }
}

