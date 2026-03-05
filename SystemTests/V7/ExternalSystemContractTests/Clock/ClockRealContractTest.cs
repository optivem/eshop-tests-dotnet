using Dsl.Port;

namespace SystemTests.V7.ExternalSystemContractTests.Clock;

public class ClockRealContractTest : BaseClockContractTest
{
    protected override ExternalSystemMode? FixedExternalSystemMode => ExternalSystemMode.Real;
}












