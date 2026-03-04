using Dsl.Port;

namespace SystemTests.ExternalSystemContractTests.V7.Tax;

public class TaxRealContractTest : BaseTaxContractTest
{
    protected override ExternalSystemMode? FixedExternalSystemMode => ExternalSystemMode.Real;
}



