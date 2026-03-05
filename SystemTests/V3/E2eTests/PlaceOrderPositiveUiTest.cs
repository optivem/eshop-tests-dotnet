using SystemTests.TestInfrastructure.Base.V3;

namespace SystemTests.V3.E2eTests;

public class PlaceOrderPositiveUiTest : PlaceOrderPositiveBaseTest
{
    protected override Task SetShopDriverAsync()
    {
        return SetUpShopUiDriverAsync();
    }
}











