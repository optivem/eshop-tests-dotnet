using Dsl.Port;
using Dsl.Core.Shared;
using SystemTests.TestInfrastructure.Base.V6;

namespace SystemTests.V6.E2eTests.Base;

public abstract class BaseE2eTest : BaseScenarioDslTest
{
    protected override ExternalSystemMode? GetFixedExternalSystemMode()
    {
        return ExternalSystemMode.Real;
    }
}












