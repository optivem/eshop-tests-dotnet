using Optivem.EShop.SystemTest.Core.Clock.Driver.Dtos;
using Commons.Util;

namespace Optivem.EShop.SystemTest.Core.Clock.Driver;

public class ClockRealDriver : IClockDriver
{
    private bool _disposed;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing)
        {
            // No resources to dispose
        }
        _disposed = true;
    }

    public Task<Result<VoidValue, ClockErrorResponse>> GoToClockAsync()
    {
        var _ = DateTimeOffset.UtcNow;
        return Task.FromResult(Result.Success<ClockErrorResponse>());
    }

    public Task<Result<GetTimeResponse, ClockErrorResponse>> GetTimeAsync()
    {
        var currentTime = DateTimeOffset.UtcNow;

        var response = new GetTimeResponse
        {
            Time = currentTime
        };

        return Task.FromResult(Result<GetTimeResponse, ClockErrorResponse>.Success(response));
    }

    public Task<Result<VoidValue, ClockErrorResponse>> ReturnsTimeAsync(ReturnsTimeRequest request)
    {
        // No-op for real driver - cannot configure system clock
        return Task.FromResult(Result.Success<ClockErrorResponse>());
    }
}
