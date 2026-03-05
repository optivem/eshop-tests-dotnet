using Dsl.Port;
using Dsl.Core.Shared;
using SystemTests.TestInfrastructure.Base.V5;

namespace SystemTests.V5.E2eTests.Base;

public abstract class BaseE2eTest : BaseSystemDslTest
{
    protected override ExternalSystemMode? GetFixedExternalSystemMode()
    {
        return ExternalSystemMode.Real;
    }
}












