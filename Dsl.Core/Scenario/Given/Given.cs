using Dsl.Core.Scenario.When;
using Dsl.Api.Given;
using Dsl.Api.Given.Steps;
using Dsl.Api.When;
using Driver.Core;
using Dsl.Core.Gherkin.Given;
using Optivem.Testing;

namespace Dsl.Core.Scenario.Given
{
    public class GivenStage : BaseClause, IGiven
    {
        private readonly SystemDsl _app;
        private readonly ScenarioDsl _scenario;
        private readonly List<GivenProduct> _products;
        private readonly List<GivenOrder> _orders;
        private GivenClock _clock;
        private readonly List<GivenCountry> _countries;
        private readonly List<GivenCoupon> _coupons;

        public GivenStage(Channel channel, SystemDsl app, ScenarioDsl scenario)
            : base(channel)
        {
            _app = app;
            _scenario = scenario;
            _products = new List<GivenProduct>();
            _orders = new List<GivenOrder>();
            _clock = new GivenClock(this);
            _countries = new List<GivenCountry>();
            _coupons = new List<GivenCoupon>();
        }

        public GivenProduct Product()
        {
            var productBuilder = new GivenProduct(this);
            _products.Add(productBuilder);
            return productBuilder;
        }

        IGivenProduct IGiven.Product() => Product();

        public GivenOrder Order()
        {
            var orderBuilder = new GivenOrder(this);
            _orders.Add(orderBuilder);
            return orderBuilder;
        }

        IGivenOrder IGiven.Order() => Order();

        public GivenClock Clock()
        {
            _clock = new GivenClock(this);
            return _clock;
        }

        IGivenClock IGiven.Clock() => Clock();

        public GivenCountry Country()
        {
            var taxRateBuilder = new GivenCountry(this);
            _countries.Add(taxRateBuilder);
            return taxRateBuilder;
        }

        IGivenCountry IGiven.Country() => Country();

        public GivenCoupon Coupon()
        {
            var couponBuilder = new GivenCoupon(this);
            _coupons.Add(couponBuilder);
            return couponBuilder;
        }

        IGivenCoupon IGiven.Coupon() => Coupon();

        public WhenStage When()
        {
            return new WhenStage(Channel, _app, _scenario, _products.Any(), _countries.Any(), SetupGiven);
        }

        IWhen IGiven.When() => When();

        private async Task SetupGiven()
        {
            await SetupClock();
            await SetupErp();
            await SetupTax();
            await SetupShop();
        }

        private async Task SetupClock()
        {
            await _clock.Execute(_app);
        }

        private async Task SetupErp()
        {
            if (_orders.Any() && !_products.Any())
            {
                var defaultProduct = new GivenProduct(this);
                _products.Add(defaultProduct);
            }

            foreach (var product in _products)
            {
                await product.Execute(_app);
            }
        }

        private async Task SetupTax()
        {
            if (_orders.Any() && !_countries.Any())
            {
                var defaultCountry = new GivenCountry(this);
                _countries.Add(defaultCountry);
            }

            foreach (var country in _countries)
            {
                await country.Execute(_app);
            }
        }

        private async Task SetupShop()
        {
            await SetupCoupons();
            await SetupOrders();
        }

        private async Task SetupCoupons()
        {
            if (_orders.Any() && !_coupons.Any())
            {
                var defaultCoupon = new GivenCoupon(this);
                _coupons.Add(defaultCoupon);
            }

            foreach (var coupon in _coupons)
            {
                await coupon.Execute(_app);
            }
        }

        private async Task SetupOrders()
        {
            foreach (var order in _orders)
            {
                await order.Execute(_app);
            }
        }
    }
}


