namespace Driver.Api.Clock.Dtos.Error;

public class ClockErrorResponse
{
    public string? Message { get; set; }

    public override string ToString()
    {
        return Message ?? string.Empty;
    }
}
