using Optivem.EShop.SystemTest.Base.V3;

namespace Optivem.EShop.SystemTest.E2eTests.V3;

public class PlaceOrderNegativeUiTest : PlaceOrderNegativeBaseTest
{
    protected override Task SetShopDriverAsync()
    {
        return SetUpShopUiDriverAsync();
    }
}
