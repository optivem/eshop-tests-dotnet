namespace DslImpl.Scenario;

/// <summary>
/// Context extracted from execution result - order number and coupon code from the executed operation.
/// </summary>
public class ExecutionResultContext
{
    public ExecutionResultContext(string? orderNumber, string? couponCode)
    {
        OrderNumber = orderNumber;
        CouponCode = couponCode;
    }

    public string? OrderNumber { get; }
    public string? CouponCode { get; }
}
