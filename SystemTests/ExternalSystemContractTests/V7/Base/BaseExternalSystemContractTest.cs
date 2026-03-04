using Dsl.Common;
using Dsl.Port;
using SystemTests.TestInfrastructure.Base.V7;

namespace SystemTests.ExternalSystemContractTests.V7.Base;

public abstract class BaseExternalSystemContractTest : BaseScenarioDslTest
{
    protected IScenarioDsl Scenario() => Feature().Scenario();

    protected abstract ExternalSystemMode? FixedExternalSystemMode { get; }

    protected sealed override ExternalSystemMode? GetFixedExternalSystemMode() => FixedExternalSystemMode;
}



