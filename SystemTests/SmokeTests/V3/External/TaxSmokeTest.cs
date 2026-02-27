using Common;
using SystemTests.TestInfrastructure.Base.V3;
using Shouldly;
using Xunit;

namespace SystemTests.SmokeTests.V3.External;

public class TaxSmokeTest : BaseDriverTest
{
    public override Task InitializeAsync()
    {
        SetUpExternalDrivers();
        return Task.CompletedTask;
    }

    [Fact]
    public async Task ShouldBeAbleToGoToTax()
    {
        var result = await _taxDriver!.GoToTaxAsync();
        result.ShouldBeSuccess();
    }
}


