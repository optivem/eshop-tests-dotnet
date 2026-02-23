using Optivem.EShop.SystemTest.Core.Clock.Dsl;
using Optivem.EShop.SystemTest.Core.Erp.Dsl;
using Optivem.EShop.SystemTest.Core.Erp.Driver;
using Optivem.EShop.SystemTest.Core.Shop.Dsl;
using Optivem.EShop.SystemTest.Core.Tax.Dsl;
using Optivem.EShop.SystemTest.Infra.Erp.Driver;
using Optivem.Testing;
using Commons.Dsl;

namespace Optivem.EShop.SystemTest.Core;

public class SystemDsl : IAsyncDisposable
{
    private readonly UseCaseContext _context;
    private readonly SystemConfiguration _configuration;
    private ShopDsl? _shop;
    private ErpDsl? _erp;
    private TaxDsl? _tax;
    private ClockDsl? _clock;

    public SystemDsl(UseCaseContext context, SystemConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public SystemDsl(SystemConfiguration configuration)
        : this(new UseCaseContext(configuration.ExternalSystemMode), configuration) { }

    public async Task<ShopDsl> Shop(Channel channel)
    {
        if (_shop == null)
        {
            _shop = await ShopDsl.CreateAsync(
                _configuration.ShopUiBaseUrl,
                _configuration.ShopApiBaseUrl,
                channel,
                _context);
        }
        return _shop;
    }

    public ErpDsl Erp() => GetOrCreate(ref _erp, () => new ErpDsl(CreateErpDriver(), _context));

    public TaxDsl Tax() => GetOrCreate(ref _tax, () => new TaxDsl(_configuration.TaxBaseUrl, _context));

    public ClockDsl Clock() => GetOrCreate(ref _clock, () => new ClockDsl(_configuration.ClockBaseUrl, _context));

    private IErpDriver CreateErpDriver()
    {
        return _context.ExternalSystemMode switch
        {
            ExternalSystemMode.Real => new ErpRealDriver(_configuration.ErpBaseUrl),
            ExternalSystemMode.Stub => new ErpStubDriver(_configuration.ErpBaseUrl),
            _ => throw new InvalidOperationException($"Unknown external system mode: {_context.ExternalSystemMode}")
        };
    }

    public async ValueTask DisposeAsync()
    {
        if (_shop != null)
            await _shop.DisposeAsync();

        _erp?.Dispose();
        _tax?.Dispose();
        _clock?.Dispose();

        ChannelContext.Clear();
    }

    private static T GetOrCreate<T>(ref T? instance, Func<T> supplier) where T : class
    {
        return instance ??= supplier();
    }
}
