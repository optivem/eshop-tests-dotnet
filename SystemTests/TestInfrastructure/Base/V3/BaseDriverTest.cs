using SystemTests.TestInfrastructure.Configuration;
using Dsl.Core;
using Driver.Api.Erp;
using Driver.Api.Shop;
using Driver.Api.Tax;
using Driver.Core.Erp;
using Driver.Core.Shop.Api;
using Driver.Core.Shop.Ui;
using Driver.Core.Tax;
using Xunit;

namespace SystemTests.TestInfrastructure.Base.V3;

public abstract class BaseDriverTest : BaseConfigurableTest, IAsyncLifetime
{
    protected readonly SystemConfiguration _configuration;
    protected IShopDriver? _shopDriver;
    protected ErpRealDriver? _erpDriver;
    protected TaxRealDriver? _taxDriver;

    protected BaseDriverTest()
    {
        _configuration = LoadConfiguration();
    }

    public virtual Task InitializeAsync() => Task.CompletedTask;

    protected void SetUpShopApiDriver()
    {
        _shopDriver = new ShopApiDriver(_configuration.ShopApiBaseUrl);
    }

    protected async Task SetUpShopUiDriverAsync()
    {
        _shopDriver = await ShopUiDriver.CreateAsync(_configuration.ShopUiBaseUrl);
    }

    protected void SetUpExternalDrivers()
    {
        _erpDriver = new ErpRealDriver(_configuration.ErpBaseUrl);
        _taxDriver = new TaxRealDriver(_configuration.TaxBaseUrl);
    }

    public virtual async Task DisposeAsync()
    {
        if (_shopDriver != null)
            await _shopDriver.DisposeAsync();
        _erpDriver?.Dispose();
        _taxDriver?.Dispose();
    }
}





