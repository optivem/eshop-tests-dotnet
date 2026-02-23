namespace Optivem.EShop.SystemTest.Core.Erp.Driver.Dtos.Error;

public class ErpErrorResponse
{
    public string? Message { get; set; }

    public override string ToString()
    {
        return Message ?? string.Empty;
    }
}