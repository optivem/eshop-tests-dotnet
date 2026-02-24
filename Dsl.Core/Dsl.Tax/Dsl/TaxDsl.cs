using Optivem.EShop.SystemTest.Driver.Api.Tax;
using Optivem.EShop.SystemTest.Dsl.Tax.Dsl.UseCases;
using Driver.Core.Driver.Commons.Dsl;

namespace Optivem.EShop.SystemTest.Dsl.Tax.Dsl;

public class TaxDsl : IDisposable
{
    private readonly ITaxDriver _driver;
    private readonly Driver.Core.Driver.Commons.Dsl.UseCaseContext _context;
    private bool _disposed;

    public TaxDsl(ITaxDriver driver, Driver.Core.Driver.Commons.Dsl.UseCaseContext context)
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

    public GoToTax GoToTax() => new(_driver, _context);
    public ReturnsTaxRate ReturnsTaxRate() => new(_driver, _context);
    public GetTaxRate GetTaxRate() => new(_driver, _context);
}
