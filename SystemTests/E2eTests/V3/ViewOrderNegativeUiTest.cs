using SystemTests.TestInfrastructure.Base.V3;

namespace SystemTests.E2eTests.V3;

public class ViewOrderNegativeUiTest : ViewOrderNegativeBaseTest
{
    protected override Task SetShopDriverAsync()
    {
        return SetUpShopUiDriverAsync();
    }
}


