using Dsl.Port;
using Dsl.Port.Background;
using Optivem.Testing;

namespace Dsl.Core;

public class BackgroundDsl : IBackgroundDsl
{
    private readonly AppDsl _app;
    private readonly Channel? _channel;

    public BackgroundDsl(AppDsl app, Channel? channel = null)
    {
        _app = app;
        _channel = channel;
    }

    public IShould Shop()
    {
        return new ShouldAction(async () =>
        {
            (await (await _app.Shop(_channel)).GoToShop().Execute()).ShouldSucceed();
        }, this);
    }

    public IShould Erp()
    {
        return new ShouldAction(async () =>
        {
            (await _app.Erp().GoToErp().Execute()).ShouldSucceed();
        }, this);
    }

    public IShould Tax()
    {
        return new ShouldAction(async () =>
        {
            (await _app.Tax().GoToTax().Execute()).ShouldSucceed();
        }, this);
    }

    public IShould Clock()
    {
        return new ShouldAction(async () =>
        {
            (await _app.Clock().GoToClock().Execute()).ShouldSucceed();
        }, this);
    }

    private class ShouldAction : IShould
    {
        private readonly Func<Task> _action;
        private readonly IBackgroundDsl _backgroundDsl;

        public ShouldAction(Func<Task> action, IBackgroundDsl backgroundDsl)
        {
            _action = action;
            _backgroundDsl = backgroundDsl;
        }

        public async Task<IBackgroundDsl> ShouldBeRunning()
        {
            await _action();
            return _backgroundDsl;
        }
    }
}
