using SystemTests.ExternalSystemContractTests.V7.Base;

namespace SystemTests.ExternalSystemContractTests.V7.Clock;

public abstract class BaseClockContractTest : BaseExternalSystemContractTest
{
    [Fact]
    public async Task ShouldBeAbleToGetTime()
    {
        (await App.Clock().ReturnsTime()
            .Time("2024-01-02T09:00:00Z")
            .Execute())
            .ShouldSucceed();

        (await App.Clock().GetTime()
            .Execute())
            .ShouldSucceed()
            .TimeIsNotNull();
    }
}

