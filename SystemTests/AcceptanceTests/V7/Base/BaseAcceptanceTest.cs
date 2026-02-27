using Dsl.Common;
using SystemTests.TestInfrastructure.Base.V7;

namespace Optivem.EShop.SystemTest.AcceptanceTests.V7.Base;

public abstract class BaseAcceptanceTest : BaseScenarioDslTest
{
    protected override ExternalSystemMode? GetFixedExternalSystemMode()
    {
        return ExternalSystemMode.Stub;
    }
}

