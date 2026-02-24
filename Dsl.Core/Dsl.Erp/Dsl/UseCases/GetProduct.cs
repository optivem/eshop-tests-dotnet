using Optivem.EShop.SystemTest.Driver.Api.Erp;
using Optivem.EShop.SystemTest.Driver.Api.Erp.Dtos;
using Optivem.EShop.SystemTest.Driver.Api.Erp.Dtos.Error;
using Optivem.EShop.SystemTest.Dsl.Erp.Dsl.UseCases.Base;
using Driver.Core.Driver.Commons.Dsl;

namespace Optivem.EShop.SystemTest.Dsl.Erp.Dsl.UseCases;

public class GetProduct : BaseErpCommand<GetProductResponse, GetProductVerification>
{
    private string? _skuParamAlias;

    public GetProduct(IErpDriver driver, Driver.Core.Driver.Commons.Dsl.UseCaseContext context)
        : base(driver, context)
    {
    }

    public GetProduct Sku(string? skuParamAlias)
    {
        _skuParamAlias = skuParamAlias;
        return this;
    }

    public override async Task<ErpDriver.Core.Driver.Commons.Dsl.UseCaseResult<GetProductResponse, GetProductVerification>> Execute()
    {
        var sku = _context.GetParamValue(_skuParamAlias);

        var request = new GetProductRequest
        {
            Sku = sku
        };

        var result = await _driver.GetProductAsync(request);

        return new ErpDriver.Core.Driver.Commons.Dsl.UseCaseResult<GetProductResponse, GetProductVerification>(
            result,
            _context,
            (response, ctx) => new GetProductVerification(response, ctx));
    }
}
