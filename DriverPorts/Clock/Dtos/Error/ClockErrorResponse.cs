namespace Optivem.EShop.SystemTest.Driver.Ports.Clock.Dtos;

public class ClockErrorResponse
{
    public string? Message { get; set; }

    public override string ToString()
    {
        return Message ?? string.Empty;
    }
}
