using Common;
using SystemTests.TestInfrastructure.Base.V4;
using Shouldly;
using Xunit;

namespace SystemTests.V4.SmokeTests.External;

public class ErpSmokeTest : BaseChannelDriverTest
{
    [Fact]
    public async Task ShouldBeAbleToGoToErp()
    {
        var result = await _erpDriver!.GoToErpAsync();
        result.ShouldBeSuccess();
    }
}










