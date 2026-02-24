using Optivem.EShop.SystemTest.Dsl.Clock.Dsl;
using Optivem.EShop.SystemTest.Driver.Api.Clock;
using Optivem.EShop.SystemTest.Dsl.Erp.Dsl;
using Optivem.EShop.SystemTest.Driver.Api.Erp;
using Optivem.EShop.SystemTest.Dsl.Shop;
using Optivem.EShop.SystemTest.Driver.Api.Shop;
using Optivem.EShop.SystemTest.Dsl.Shop.Dsl;
using Optivem.EShop.SystemTest.Driver.Api.Tax;
using Optivem.EShop.SystemTest.Dsl.Tax.Dsl;
using Optivem.EShop.SystemTest.Driver.Erp.Driver;
using Optivem.Testing;
using Driver.Core.Driver.Commons.Dsl;
using Optivem.EShop.SystemTest.Dsl.Shop.Driver;
using Optivem.EShop.SystemTest.Dsl.Tax.Driver;
using Optivem.EShop.SystemTest.Dsl.Clock.Driver;

namespace Optivem.EShop.SystemTest.Core;

public class SystemDsl : IAsyncDisposable
{
    private readonly Driver.Core.Driver.Commons.Dsl.UseCaseContext _context;
    private readonly SystemConfiguration _configuration;
    private ShopDsl? _shop;
    private ErpDsl? _erp;
    private TaxDsl? _tax;
    private ClockDsl? _clock;

    public SystemDsl(Driver.Core.Driver.Commons.Dsl.UseCaseContext context, SystemConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public SystemDsl(SystemConfiguration configuration)
        : this(new Driver.Core.Driver.Commons.Dsl.UseCaseContext(configuration.ExternalSystemMode), configuration) { }

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

