using Optivem.EShop.SystemTest.Base.V3;

namespace Optivem.EShop.SystemTest.E2eTests.V3;

public class ViewOrderNegativeApiTest : ViewOrderNegativeBaseTest
{
    protected override Task SetShopDriverAsync()
    {
        SetUpShopApiDriver();
        return Task.CompletedTask;
    }
}
