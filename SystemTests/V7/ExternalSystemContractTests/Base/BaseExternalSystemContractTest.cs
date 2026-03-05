using Dsl.Port;
using Dsl.Core.Shared;
using SystemTests.TestInfrastructure.Base.V7;

namespace SystemTests.V7.ExternalSystemContractTests.Base;

public abstract class BaseExternalSystemContractTest : BaseScenarioDslTest
{
    protected abstract ExternalSystemMode? FixedExternalSystemMode { get; }

    protected sealed override ExternalSystemMode? GetFixedExternalSystemMode() => FixedExternalSystemMode;
}













