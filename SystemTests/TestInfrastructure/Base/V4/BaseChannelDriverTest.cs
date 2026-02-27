using Optivem.EShop.SystemTest.Configuration;
using Dsl.Core;
using Driver.Api.Erp;
using Driver.Core.Shop;
using Driver.Api.Shop;
using Driver.Api.Tax;
using Driver.Core.Erp;
using Driver.Core.Tax;
using Optivem.Testing;
using Xunit;

namespace Optivem.EShop.SystemTest.Base.V4;


public abstract class BaseChannelDriverTest : BaseConfigurableTest, IAsyncLifetime
{
    protected IShopDriver? _shopDriver;
    protected ErpRealDriver? _erpDriver;
    protected TaxRealDriver? _taxDriver;

    public virtual async Task InitializeAsync()
    {
        var configuration = LoadConfiguration();

        // Only create shop driver if channel context is set (for channel-parameterized tests)
        // For non-channel tests (like Erp/Tax), skip shop driver creation
        try
        {
            _shopDriver = await CreateShopDriverAsync(configuration);
        }
        catch (InvalidOperationException ex) when (ex.Message.Contains("Channel type is not set"))
        {
            _shopDriver = null;
        }

        _erpDriver = new ErpRealDriver(configuration.ErpBaseUrl);
        _taxDriver = new TaxRealDriver(configuration.TaxBaseUrl);
    }

    public virtual async Task DisposeAsync()
    {
        if (_shopDriver != null)
            await _shopDriver.DisposeAsync();

        _erpDriver?.Dispose();
        _taxDriver?.Dispose();
    }

    protected async Task SetChannelAsync(Channel channel)
    {
        ChannelContext.Set(channel.Type);
        await InitializeAsync();
    }

    private static async Task<IShopDriver?> CreateShopDriverAsync(SystemConfiguration configuration)
    {
        var channelType = ChannelContext.Get();

        if (channelType == ChannelType.UI)
        {
            return await ShopUiDriver.CreateAsync(configuration.ShopUiBaseUrl);
        }
        else if (channelType == ChannelType.API)
        {
            return new ShopApiDriver(configuration.ShopApiBaseUrl);
        }
        else
        {
            throw new InvalidOperationException($"Unknown channel: {channelType}");
        }
    }
}




