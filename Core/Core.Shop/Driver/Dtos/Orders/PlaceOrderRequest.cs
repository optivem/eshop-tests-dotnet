namespace Optivem.EShop.SystemTest.Core.Shop.Driver.Dtos.Orders;

public class PlaceOrderRequest
{
    public string? Sku { get; set; }
    public string? Quantity { get; set; }
    public string? Country { get; set; }
    public string? CouponCode { get; set; }
}