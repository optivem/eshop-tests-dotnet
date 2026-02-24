using Optivem.EShop.SystemTest.Dsl.Clock.Dsl.UseCases;
using Optivem.EShop.SystemTest.Driver.Api.Clock;
using Driver.Core.Driver.Commons.Dsl;

namespace Optivem.EShop.SystemTest.Dsl.Clock.Dsl;

public class ClockDsl : IDisposable
{
    private readonly IClockDriver _driver;
    private readonly Driver.Core.Driver.Commons.Dsl.UseCaseContext _context;
    private bool _disposed;

    public ClockDsl(IClockDriver driver, Driver.Core.Driver.Commons.Dsl.UseCaseContext context)
    {
        _driver = driver;
        _context = context;
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
            _driver?.Dispose();
        _disposed = true;
    }

    public GoToClock GoToClock() => new(_driver, _context);

    public ReturnsTime ReturnsTime() => new(_driver, _context);

    public GetTime GetTime() => new(_driver, _context);
}
