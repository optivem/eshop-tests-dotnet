using Optivem.EShop.SystemTest.Driver.Ports.Clock.Dtos;
using Commons.Util;

namespace Optivem.EShop.SystemTest.Driver.Ports.Clock;

public interface IClockDriver : IDisposable
{
    Task<Result<VoidValue, ClockErrorResponse>> GoToClockAsync();
    Task<Result<GetTimeResponse, ClockErrorResponse>> GetTimeAsync();
    Task<Result<VoidValue, ClockErrorResponse>> ReturnsTimeAsync(ReturnsTimeRequest request);
}
