using Dsl.Core.Clock.Dsl;
using Driver.Port.Clock;
using Dsl.Core.Erp.Dsl;
using Driver.Port.Erp;
using Driver.Adapter.Shop.Api;
using Driver.Adapter.Shop.Ui;
using Dsl.Core.Shop;
using Driver.Port.Shop;
using Dsl.Core.Shop.Dsl;
using Driver.Port.Tax;
using Dsl.Core.Tax.Dsl;
using Driver.Adapter.Erp;
using Optivem.Testing;
using Dsl.Common;
using Driver.Adapter.Clock;
using Driver.Adapter.Tax;

namespace Dsl.Core;

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
            _shop = await ShopDsl.CreateAsync(await CreateShopDriverAsync(channel), _context);
        }
        return _shop;
    }

    public ErpDsl Erp() => GetOrCreate(ref _erp, () => new ErpDsl(CreateErpDriver(), _context));

    public TaxDsl Tax() => GetOrCreate(ref _tax, () => new TaxDsl(CreateTaxDriver(), _context));

    public ClockDsl Clock() => GetOrCreate(ref _clock, () => new ClockDsl(CreateClockDriver(), _context));

    private async Task<IShopDriver> CreateShopDriverAsync(Channel channel)
    {
        return channel.Type switch
        {
            ChannelType.UI => await ShopUiDriver.CreateAsync(_configuration.ShopUiBaseUrl),
            ChannelType.API => new ShopApiDriver(_configuration.ShopApiBaseUrl),
            _ => throw new InvalidOperationException($"Unknown channel: {channel}")
        };
    }

    private IErpDriver CreateErpDriver()
    {
        return _context.ExternalSystemMode switch
        {
            ExternalSystemMode.Real => new ErpRealDriver(_configuration.ErpBaseUrl),
            ExternalSystemMode.Stub => new ErpStubDriver(_configuration.ErpBaseUrl),
            _ => throw new InvalidOperationException($"Unknown external system mode: {_context.ExternalSystemMode}")
        };
    }

    private ITaxDriver CreateTaxDriver()
    {
        return _context.ExternalSystemMode switch
        {
            ExternalSystemMode.Real => new TaxRealDriver(_configuration.TaxBaseUrl),
            ExternalSystemMode.Stub => new TaxStubDriver(_configuration.TaxBaseUrl),
            _ => throw new InvalidOperationException($"Unknown external system mode: {_context.ExternalSystemMode}")
        };
    }

    private IClockDriver CreateClockDriver()
    {
        return _context.ExternalSystemMode switch
        {
            ExternalSystemMode.Real => new ClockRealDriver(),
            ExternalSystemMode.Stub => new ClockStubDriver(_configuration.ClockBaseUrl),
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




