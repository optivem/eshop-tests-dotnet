using Optivem.EShop.SystemTest.Driver.Api.Clock.Dtos;
using Common;

namespace Optivem.EShop.SystemTest.Driver.Api.Clock;

public interface IClockDriver : IDisposable
{
    Task<Result<VoidValue, ClockErrorResponse>> GoToClockAsync();
    Task<Result<GetTimeResponse, ClockErrorResponse>> GetTimeAsync();
    Task<Result<VoidValue, ClockErrorResponse>> ReturnsTimeAsync(ReturnsTimeRequest request);
}
