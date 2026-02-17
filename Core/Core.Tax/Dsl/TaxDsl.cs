using Optivem.EShop.SystemTest.Core.Tax.Driver;
using Optivem.EShop.SystemTest.Core.Tax.Dsl.UseCases;
using Commons.Dsl;

namespace Optivem.EShop.SystemTest.Core.Tax.Dsl;

public class TaxDsl : IDisposable
{
    private readonly ITaxDriver _driver;
    private readonly UseCaseContext _context;
    private bool _disposed;

    private TaxDsl(ITaxDriver driver, UseCaseContext context)
    {
        _driver = driver;
        _context = context;
    }

    public TaxDsl(string baseUrl, UseCaseContext context)
        : this(CreateDriver(baseUrl, context), context)
    {
    }

    private static ITaxDriver CreateDriver(string baseUrl, UseCaseContext context)
    {
        return context.ExternalSystemMode switch
        {
            ExternalSystemMode.Real => new TaxRealDriver(baseUrl),
            ExternalSystemMode.Stub => new TaxStubDriver(baseUrl),
            _ => throw new ArgumentOutOfRangeException($"Unknown mode: {context.ExternalSystemMode}")
        };
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
