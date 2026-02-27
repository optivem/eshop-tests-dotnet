using SystemTests.ExternalSystemContractTests.V7.Base;

namespace SystemTests.ExternalSystemContractTests.V7.Tax;

public abstract class BaseTaxContractTest : BaseExternalSystemContractTest
{
    [Fact]
    public async Task ShouldBeAbleToGetTaxRate()
    {
        (await App.Tax().ReturnsTaxRate()
            .Country("US")
            .TaxRate(0.09m)
            .Execute())
            .ShouldSucceed();

        (await App.Tax().GetTaxRate()
            .Country("US")
            .Execute())
            .ShouldSucceed()
            .Country("US")
            .TaxRateIsPositive();
    }
}

