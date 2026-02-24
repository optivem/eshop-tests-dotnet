using Optivem.EShop.SystemTest.Driver.Api.Erp;
using Optivem.EShop.SystemTest.Driver.Api.Erp.Dtos;
using Optivem.EShop.SystemTest.Driver.Api.Erp.Dtos.Error;
using Optivem.EShop.SystemTest.Dsl.Erp.Dsl.UseCases.Base;
using Commons.Util;
using Driver.Core.Driver.Commons.Dsl;

namespace Optivem.EShop.SystemTest.Dsl.Erp.Dsl.UseCases;

public class ReturnsProduct : BaseErpCommand<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>
{
    private string? _skuParamAlias;
    private string? _unitPrice;

    public ReturnsProduct(IErpDriver driver, Driver.Core.Driver.Commons.Dsl.UseCaseContext context)
        : base(driver, context)
    {
    }

    public ReturnsProduct Sku(string? skuParamAlias)
    {
        _skuParamAlias = skuParamAlias;
        return this;
    }

    public ReturnsProduct UnitPrice(string? unitPrice)
    {
        _unitPrice = unitPrice;
        return this;
    }

    public ReturnsProduct UnitPrice(decimal price)
    {
        return UnitPrice(price.ToString());
    }

    public override async Task<ErpDriver.Core.Driver.Commons.Dsl.UseCaseResult<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>> Execute()
    {
        var sku = _context.GetParamValue(_skuParamAlias);

        var request = new ReturnsProductRequest
        {
            Sku = sku,
            Price = _unitPrice
        };

        var result = await _driver.ReturnsProductAsync(request);

        return new ErpDriver.Core.Driver.Commons.Dsl.UseCaseResult<VoidValue, Driver.Core.Driver.Commons.Dsl.VoidVerification>(
            result,
            _context,
            (response, ctx) => new Driver.Core.Driver.Commons.Dsl.VoidVerification(response, ctx));
    }
}
