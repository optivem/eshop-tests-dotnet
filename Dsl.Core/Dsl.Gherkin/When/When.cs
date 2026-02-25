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
    public class WhenClause : BaseClause, IWhenClause
    {
        private readonly SystemDsl _app;
        private readonly ScenarioDsl _scenario;
        private bool _hasProduct;
        private bool _hasTaxRate;
        private readonly Func<Task>? _givenSetup;

        public WhenClause(Channel channel, SystemDsl app, ScenarioDsl scenario, bool hasProduct, bool hasTaxRate, Func<Task>? givenSetup = null)
            : base(channel)
        {
            _app = app;
            _scenario = scenario;
            _hasProduct = hasProduct;
            _hasTaxRate = hasTaxRate;
            _givenSetup = givenSetup;
        }

        public WhenClause(Channel channel, SystemDsl app, ScenarioDsl scenario)
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

        public GoToShopBuilder GoToShop()
        {
            return new GoToShopBuilder(_app, _scenario, () => EnsureGiven());
        }

        IGoToShopBuilder IWhenClause.GoToShop() => GoToShop();

        public PlaceOrderBuilder PlaceOrder()
        {
            return new PlaceOrderBuilder(_app, _scenario, () => EnsureGiven());
        }

        IPlaceOrderBuilder IWhenClause.PlaceOrder() => PlaceOrder();

        public CancelOrderBuilder CancelOrder()
        {
            return new CancelOrderBuilder(_app, _scenario, () => EnsureGiven());
        }

        ICancelOrderBuilder IWhenClause.CancelOrder() => CancelOrder();

        public ViewOrderBuilder ViewOrder()
        {
            return new ViewOrderBuilder(_app, _scenario, () => EnsureGiven());
        }

        IViewOrderBuilder IWhenClause.ViewOrder() => ViewOrder();

        public PublishCouponBuilder PublishCoupon()
        {
            return new PublishCouponBuilder(_app, _scenario, () => EnsureGiven());
        }

        IPublishCouponBuilder IWhenClause.PublishCoupon() => PublishCoupon();

        public BrowseCouponsBuilder BrowseCoupons()
        {
            return new BrowseCouponsBuilder(_app, _scenario, () => EnsureGiven());
        }

        IBrowseCouponsBuilder IWhenClause.BrowseCoupons() => BrowseCoupons();
    }
}
