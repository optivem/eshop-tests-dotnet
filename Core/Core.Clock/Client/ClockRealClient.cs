using Commons.Util;
using Optivem.EShop.SystemTest.Core.Clock.Client.Dtos;
using Optivem.EShop.SystemTest.Core.Clock.Client.Dtos.Error;

namespace Optivem.EShop.SystemTest.Core.Clock.Client;

public class ClockRealClient
{
    public Task<Result<VoidValue, ExtClockErrorResponse>> CheckHealthAsync()
    {
        var _ = DateTimeOffset.UtcNow;
        return Task.FromResult(Result.Success<ExtClockErrorResponse>());
    }

    public Task<Result<ExtGetTimeResponse, ExtClockErrorResponse>> GetTimeAsync()
        => Task.FromResult(Result<ExtGetTimeResponse, ExtClockErrorResponse>.Success(
            new ExtGetTimeResponse { Time = DateTimeOffset.UtcNow }));
}
