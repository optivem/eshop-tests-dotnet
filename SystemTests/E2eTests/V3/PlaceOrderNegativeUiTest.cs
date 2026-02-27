using SystemTests.TestInfrastructure.Base.V3;

namespace SystemTests.E2eTests.V3;

public class PlaceOrderNegativeUiTest : PlaceOrderNegativeBaseTest
{
    protected override Task SetShopDriverAsync()
    {
        return SetUpShopUiDriverAsync();
    }
}


