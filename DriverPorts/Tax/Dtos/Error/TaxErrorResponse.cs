namespace Optivem.EShop.SystemTest.Driver.Ports.Tax.Dtos.Error;

public class TaxErrorResponse
{
    public string? Message { get; set; }

    public override string ToString()
    {
        return Message ?? string.Empty;
    }
}
