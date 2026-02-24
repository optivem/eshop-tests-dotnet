namespace Optivem.EShop.SystemTest.Driver.Ports.Erp.Dtos.Error;

public class ErpErrorResponse
{
    public string? Message { get; set; }

    public override string ToString()
    {
        return Message ?? string.Empty;
    }
}
