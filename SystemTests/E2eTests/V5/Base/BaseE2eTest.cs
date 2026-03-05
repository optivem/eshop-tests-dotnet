using Dsl.Port;
using Dsl.Core.Shared;
using SystemTests.TestInfrastructure.Base.V5;

namespace SystemTests.E2eTests.V5.Base;

public abstract class BaseE2eTest : BaseSystemDslTest
{
    protected override ExternalSystemMode? GetFixedExternalSystemMode()
    {
        return ExternalSystemMode.Real;
    }
}



