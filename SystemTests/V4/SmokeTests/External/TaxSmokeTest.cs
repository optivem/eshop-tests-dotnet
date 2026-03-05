using Common;
using SystemTests.TestInfrastructure.Base.V4;
using Shouldly;
using Xunit;

namespace SystemTests.V4.SmokeTests.External;

public class TaxSmokeTest : BaseChannelDriverTest
{
    [Fact]
    public async Task ShouldBeAbleToGoToTax()
    {
        var result = await _taxDriver!.GoToTaxAsync();
        result.ShouldBeSuccess();
    }
}










