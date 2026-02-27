using SystemTests.TestInfrastructure.Base.V3;

namespace Optivem.EShop.SystemTest.E2eTests.V3;

public class ViewOrderPositiveUiTest : ViewOrderPositiveBaseTest
{
    protected override Task SetShopDriverAsync()
    {
        return SetUpShopUiDriverAsync();
    }
}

