using Optivem.EShop.SystemTest.Driver.Api.Erp;
using Optivem.EShop.SystemTest.Core.Erp.Dsl.UseCases;
using Dsl.Common;

namespace Optivem.EShop.SystemTest.Core.Erp.Dsl;

public class ErpDsl : IDisposable
{
    private readonly IErpDriver _driver;
    private readonly UseCaseContext _context;
    private bool _disposed;

    public ErpDsl(IErpDriver driver, UseCaseContext context)
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
