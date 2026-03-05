using SystemTests.V7.ExternalSystemContractTests.Base;

namespace SystemTests.V7.ExternalSystemContractTests.Clock;

public abstract class BaseClockContractTest : BaseExternalSystemContractTest
{
    [Fact]
    public async Task ShouldBeAbleToGetTime()
    {
        (await Scenario()
            .Given().Clock().WithTime("2024-01-02T09:00:00Z")
            .Then().Clock())
            .HasTime();
    }
}










