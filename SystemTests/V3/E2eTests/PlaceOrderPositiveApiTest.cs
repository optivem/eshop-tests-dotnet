using SystemTests.TestInfrastructure.Base.V3;

namespace SystemTests.V3.E2eTests;

public class PlaceOrderPositiveApiTest : PlaceOrderPositiveBaseTest
{
    protected override Task SetShopDriverAsync()
    {
        SetUpShopApiDriver();
        return Task.CompletedTask;
    }
}











