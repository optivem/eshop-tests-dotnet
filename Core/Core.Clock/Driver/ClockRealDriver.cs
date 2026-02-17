using Optivem.EShop.SystemTest.Core.Clock.Driver.Dtos;
using Optivem.EShop.SystemTest.Core.Clock.Client;
using Commons.Util;
using Optivem.EShop.SystemTest.Core.Clock.Client.Dtos;

namespace Optivem.EShop.SystemTest.Core.Clock.Driver;

public class ClockRealDriver : IClockDriver
{
    private readonly ClockRealClient _client;
    private bool _disposed;

    public ClockRealDriver()
    {
        _client = new ClockRealClient();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;
        _disposed = true;
    }

    public Task<Result<VoidValue, ClockErrorResponse>> GoToClockAsync()
        => ClockRealClient.CheckHealthAsync().MapErrorAsync(ClockErrorResponse.From);

    public Task<Result<GetTimeResponse, ClockErrorResponse>> GetTimeAsync()
        => _client.GetTimeAsync().MapAsync(GetTimeResponse.From).MapErrorAsync(ClockErrorResponse.From);

    public Task<Result<VoidValue, ClockErrorResponse>> ReturnsTimeAsync(ReturnsTimeRequest request)
    {
        // No-op for real driver - cannot configure system clock
        return Task.FromResult(Result.Success<ClockErrorResponse>());
    }
}
