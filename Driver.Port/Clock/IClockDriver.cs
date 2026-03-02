using Driver.Port.Clock.Dtos;
using Common;

namespace Driver.Port.Clock;

public interface IClockDriver : IDisposable
{
    Task<Result<VoidValue, ClockErrorResponse>> GoToClockAsync();
    Task<Result<GetTimeResponse, ClockErrorResponse>> GetTimeAsync();
    Task<Result<VoidValue, ClockErrorResponse>> ReturnsTimeAsync(ReturnsTimeRequest request);
}

