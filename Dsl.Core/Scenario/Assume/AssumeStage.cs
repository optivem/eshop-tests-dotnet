using Dsl.Port.Assume;
using Optivem.Testing;

namespace Dsl.Core.Scenario.Assume;

public class AssumeStage : IAssumeStage
{
    private readonly AppDsl _app;
    private readonly Channel? _channel;

    public AssumeStage(AppDsl app, Channel? channel = null)
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
        private readonly IAssumeStage _assumeStage;

        public ShouldAction(Func<Task> action, IAssumeStage assumeStage)
        {
            _action = action;
            _assumeStage = assumeStage;
        }

        public async Task<IAssumeStage> ShouldBeRunning()
        {
            await _action();
            return _assumeStage;
        }
    }
}
