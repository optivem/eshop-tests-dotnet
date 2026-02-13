using Optivem.EShop.SystemTest.Core.Clock.Driver.Dtos;
using Optivem.EShop.SystemTest.Core.Clock.Client;
using Commons.Util;
using ClientDtos = Optivem.EShop.SystemTest.Core.Clock.Client.Dtos;
using Optivem.EShop.SystemTest.Core.Clock.Client.Dtos;

namespace Optivem.EShop.SystemTest.Core.Clock.Driver;

public class ClockStubDriver : IClockDriver
{
    private readonly ClockStubClient _client;
    private bool _disposed;

    public ClockStubDriver(string baseUrl)
    {
        _client = new ClockStubClient(baseUrl);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing)
            _client?.Dispose();
        _disposed = true;
    }

    public Task<Result<VoidValue, ClockErrorResponse>> GoToClockAsync()
        => _client.CheckHealthAsync().MapErrorAsync(ClockErrorResponse.From);

    public Task<Result<GetTimeResponse, ClockErrorResponse>> GetTimeAsync()
        => _client.GetTimeAsync().MapAsync(GetTimeResponse.From).MapErrorAsync(ClockErrorResponse.From);

    public async Task<Result<VoidValue, ClockErrorResponse>> ReturnsTimeAsync(ReturnsTimeRequest request)
    {
        var extResponse = new ExtGetTimeResponse
        {
            Time = DateTimeOffset.Parse(request.Time!, System.Globalization.CultureInfo.InvariantCulture)
        };
        await _client.ConfigureGetTimeAsync(extResponse);
        return Result.Success<ClockErrorResponse>();
    }


}
