using D.Dtos;
using Common;

namespace Driver.Api.Clock;

public interface IClockDriver : IDisposable
{
    Task<Result<VoidValue, ClockErrorResponse>> GoToClockAsync();
    Task<Result<GetTimeResponse, ClockErrorResponse>> GetTimeAsync();
    Task<Result<VoidValue, ClockErrorResponse>> ReturnsTimeAsync(ReturnsTimeRequest request);
}
