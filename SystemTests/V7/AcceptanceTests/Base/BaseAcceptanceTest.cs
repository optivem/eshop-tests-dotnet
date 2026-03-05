using Dsl.Port;
using Dsl.Core.Shared;
using SystemTests.TestInfrastructure.Base.V7;

namespace SystemTests.V7.AcceptanceTests.Base;

public abstract class BaseAcceptanceTest : BaseScenarioDslTest
{
    protected override ExternalSystemMode? GetFixedExternalSystemMode()
    {
        return ExternalSystemMode.Stub;
    }
}












