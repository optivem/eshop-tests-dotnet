using SystemTests.ExternalSystemContractTests.V7.Base;

namespace SystemTests.ExternalSystemContractTests.V7.Erp;

public abstract class BaseErpContractTest : BaseExternalSystemContractTest
{
    [Fact]
    public async Task ShouldBeAbleToGetProduct()
    {
        (await App.Erp().ReturnsProduct()
            .Sku("SKU-123")
            .UnitPrice(12.0m)
            .Execute())
            .ShouldSucceed();

        (await App.Erp().GetProduct()
            .Sku("SKU-123")
            .Execute())
            .ShouldSucceed()
            .Sku("SKU-123")
            .Price(12.0m);
    }
}

