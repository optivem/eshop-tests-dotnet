using Dsl.Common;
using SystemTests.TestInfrastructure.Base.V5;
using Dsl.Core;

namespace SystemTests.ExternalSystemContractTests.V7.Base;

public abstract class BaseExternalSystemContractTest : BaseSystemDslTest
{
    protected AppDsl App => _app;

    protected abstract ExternalSystemMode? FixedExternalSystemMode { get; }

    protected sealed override ExternalSystemMode? GetFixedExternalSystemMode() => FixedExternalSystemMode;
}



