using Optivem.EShop.SystemTest.Driver.Api.Shop;
using Optivem.EShop.SystemTest.Core.Shop.Dsl.UseCases.Base;
using Optivem.EShop.SystemTest.Driver.Api.Shop.Dtos;
using Optivem.EShop.SystemTest.Driver.Api.Shop.Dtos.Error;
using Dsl.Common;

namespace Optivem.EShop.SystemTest.Core.Shop.Dsl.UseCases;

public class PlaceOrder : BaseShopCommand<PlaceOrderResponse, PlaceOrderVerification>
{
    private string? _orderNumberResultAlias;
    private string? _skuParamAlias;
    private string? _quantity;
    private string? _countryAlias;
    private string? _couponCodeAlias;

    public PlaceOrder(IShopDriver driver, UseCaseContext context)
        : base(driver, context)
    {
    }

    public PlaceOrder OrderNumber(string? orderNumberResultAlias)
    {
        _orderNumberResultAlias = orderNumberResultAlias;
        return this;
    }

    public PlaceOrder Sku(string? skuParamAlias)
    {
        _skuParamAlias = skuParamAlias;
        return this;
    }

    public PlaceOrder Quantity(string? quantity)
    {
        _quantity = quantity;
        return this;
    }

    public PlaceOrder Quantity(int quantity)
    {
        return Quantity(quantity.ToString());
    }

    public PlaceOrder Country(string? countryAlias)
    {
        _countryAlias = countryAlias;
        return this;
    }

    public PlaceOrder CouponCode(string? couponCodeAlias)
    {
        _couponCodeAlias = couponCodeAlias;
        return this;
    }

    public override async Task<ShopUseCaseResult<PlaceOrderResponse, PlaceOrderVerification>> Execute()
    {
        var sku = _context.GetParamValue(_skuParamAlias);
        var country = _context.GetParamValueOrLiteral(_countryAlias);
        var couponCode = _context.GetParamValue(_couponCodeAlias);

        var request = new PlaceOrderRequest
        {
            Sku = sku,
            Quantity = _quantity,
            Country = country,
            CouponCode = couponCode
        };

        var result = await _driver.PlaceOrderAsync(request);

        if (_orderNumberResultAlias != null)
        {
            if (result.IsSuccess)
            {
                var orderNumber = result.Value.OrderNumber;
                _context.SetResultEntry(_orderNumberResultAlias, orderNumber);
            }
            else
            {
                _context.SetResultEntryFailed(_orderNumberResultAlias, result.Error.ToString());
            }
        }

        return new ShopUseCaseResult<PlaceOrderResponse, PlaceOrderVerification>(
            result,
            _context,
            (response, ctx) => new PlaceOrderVerification(response, ctx));
    }
}
