using SystemTests.TestInfrastructure.Base.V3;

namespace SystemTests.E2eTests.V3;

public class ViewOrderNegativeApiTest : ViewOrderNegativeBaseTest
{
    protected override Task SetShopDriverAsync()
    {
        SetUpShopApiDriver();
        return Task.CompletedTask;
    }
}


