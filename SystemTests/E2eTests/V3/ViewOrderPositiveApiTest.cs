using SystemTests.TestInfrastructure.Base.V3;

namespace SystemTests.E2eTests.V3;

public class ViewOrderPositiveApiTest : ViewOrderPositiveBaseTest
{
    protected override Task SetShopDriverAsync()
    {
        SetUpShopApiDriver();
        return Task.CompletedTask;
    }
}


