using DslImpl.Gherkin.Builders.When.PlaceOrder;
using DslImpl.Gherkin.Builders.When.CancelOrder;
using DslImpl.Gherkin.When;
using DslImpl.Gherkin.Then;
using Dsl.Api.When;
using Dsl.Api.When.Steps;
using Optivem.Testing;
using Optivem.EShop.SystemTest.Core;
using Optivem.EShop.SystemTest.Core.Gherkin;
using Optivem.EShop.SystemTest.Core.Gherkin.When;
using static Optivem.EShop.SystemTest.Core.Gherkin.GherkinDefaults;

namespace DslImpl.Gherkin.When
{
    public class WhenStage : BaseClause, IWhen
    {
        private readonly SystemDsl _app;
        private readonly ScenarioDsl _scenario;
        private bool _hasProduct;
        private bool _hasTaxRate;
        private readonly Func<Task>? _givenSetup;

        public WhenStage(Channel channel, SystemDsl app, ScenarioDsl scenario, bool hasProduct, bool hasTaxRate, Func<Task>? givenSetup = null)
            : base(channel)
        {
            _app = app;
            _scenario = scenario;
            _hasProduct = hasProduct;
            _hasTaxRate = hasTaxRate;
            _givenSetup = givenSetup;
        }

        public WhenStage(Channel channel, SystemDsl app, ScenarioDsl scenario)
            : this(channel, app, scenario, false, false, null)
        {
        }

        private async Task EnsureGiven()
        {
            if (_givenSetup != null)
            {
                await _givenSetup();
            }

            if (!_hasProduct)
            {
                var result = await _app.Erp().ReturnsProduct()
                    .Sku(DefaultSku)
                    .UnitPrice(DefaultUnitPrice)
                    .Execute();
                result.ShouldSucceed();
                _hasProduct = true;
            }

            if (!_hasTaxRate)
            {
                var result = await _app.Tax().ReturnsTaxRate()
                    .Country(DefaultCountry)
                    .TaxRate(DefaultTaxRate)
                    .Execute();
                result.ShouldSucceed();
                _hasTaxRate = true;
            }
        }

        public GoToShop GoToShop()
        {
            return new GoToShop(_app, _scenario, () => EnsureGiven());
        }

        IGoToShop IWhen.GoToShop() => GoToShop();

        public PlaceOrder PlaceOrder()
        {
            return new PlaceOrder(_app, _scenario, () => EnsureGiven());
        }

        IPlaceOrder IWhen.PlaceOrder() => PlaceOrder();

        public CancelOrder CancelOrder()
        {
            return new CancelOrder(_app, _scenario, () => EnsureGiven());
        }

        ICancelOrder IWhen.CancelOrder() => CancelOrder();

        public ViewOrder ViewOrder()
        {
            return new ViewOrder(_app, _scenario, () => EnsureGiven());
        }

        IViewOrder IWhen.ViewOrder() => ViewOrder();

        public PublishCoupon PublishCoupon()
        {
            return new PublishCoupon(_app, _scenario, () => EnsureGiven());
        }

        IPublishCoupon IWhen.PublishCoupon() => PublishCoupon();

        public BrowseCoupons BrowseCoupons()
        {
            return new BrowseCoupons(_app, _scenario, () => EnsureGiven());
        }

        IBrowseCoupons IWhen.BrowseCoupons() => BrowseCoupons();
    }
}
