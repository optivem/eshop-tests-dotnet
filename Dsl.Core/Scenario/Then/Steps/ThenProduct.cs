using Dsl.Core.Erp.UseCases;
using Dsl.Port.Then.Steps;

namespace Dsl.Core.Scenario.Then.Steps;

public class ThenProduct : IThenProduct
{
    private readonly GetProductVerification _verification;

    public ThenProduct(GetProductVerification verification)
    {
        _verification = verification;
    }

    public IThenProduct HasSku(string sku)
    {
        _verification.Sku(sku);
        return this;
    }

    public IThenProduct HasPrice(decimal price)
    {
        _verification.Price(price);
        return this;
    }
}
