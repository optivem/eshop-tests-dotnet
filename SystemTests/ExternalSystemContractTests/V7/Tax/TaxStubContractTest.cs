namespace Optivem.EShop.SystemTest.ExternalSystemContractTests.V7.Tax;

public class TaxStubContractTest : BaseTaxContractTest
{
    protected override ExternalSystemMode? FixedExternalSystemMode => ExternalSystemMode.Stub;

    [Fact]
    public async Task ShouldBeAbleToGetConfiguredTaxRate()
    {
        (await App.Tax().ReturnsTaxRate()
            .Country("LALA")
            .TaxRate(0.23m)
            .Execute())
            .ShouldSucceed();

        (await App.Tax().GetTaxRate()
            .Country("LALA")
            .Execute())
            .ShouldSucceed()
            .Country("LALA")
            .TaxRate(0.23m);
    }
}
