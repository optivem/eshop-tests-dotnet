using Optivem.EShop.SystemTest.Driver.Api.Erp;
using Optivem.EShop.SystemTest.Dsl.Erp.Dsl.UseCases;
using Driver.Core.Driver.Commons.Dsl;

namespace Optivem.EShop.SystemTest.Dsl.Erp.Dsl;

public class ErpDsl : IDisposable
{
    private readonly IErpDriver _driver;
    private readonly Driver.Core.Driver.Commons.Dsl.UseCaseContext _context;
    private bool _disposed;

    public ErpDsl(IErpDriver driver, Driver.Core.Driver.Commons.Dsl.UseCaseContext context)
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

    public GoToErp GoToErp() => new(_driver, _context);

    public ReturnsProduct ReturnsProduct() => new(_driver, _context);

    public GetProduct GetProduct() => new(_driver, _context);
}
