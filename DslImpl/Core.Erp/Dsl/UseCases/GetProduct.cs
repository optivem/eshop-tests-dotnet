using Optivem.EShop.SystemTest.Driver.Ports.Erp;
using Optivem.EShop.SystemTest.Driver.Ports.Erp.Dtos;
using Optivem.EShop.SystemTest.Driver.Ports.Erp.Dtos.Error;
using Optivem.EShop.SystemTest.Core.Erp.Dsl.UseCases.Base;
using Driver.Shared.Dsl;

namespace Optivem.EShop.SystemTest.Core.Erp.Dsl.UseCases;

public class GetProduct : BaseErpCommand<GetProductResponse, GetProductVerification>
{
    private string? _skuParamAlias;

    public GetProduct(IErpDriver driver, UseCaseContext context)
        : base(driver, context)
    {
    }

    public GetProduct Sku(string? skuParamAlias)
    {
        _skuParamAlias = skuParamAlias;
        return this;
    }

    public override async Task<ErpUseCaseResult<GetProductResponse, GetProductVerification>> Execute()
    {
        var sku = _context.GetParamValue(_skuParamAlias);

        var request = new GetProductRequest
        {
            Sku = sku
        };

        var result = await _driver.GetProductAsync(request);

        return new ErpUseCaseResult<GetProductResponse, GetProductVerification>(
            result,
            _context,
            (response, ctx) => new GetProductVerification(response, ctx));
    }
}
