using DslImpl.Scenario.Given;
using DslImpl.Scenario.When;
using Dsl.Api;
using Dsl.Api.Given;
using Dsl.Api.When;
using Driver.Core;
using Optivem.Testing;
using System;

namespace DslImpl.Scenario;

public class ScenarioDsl : IScenarioDsl
{
    private readonly Channel _channel;
    private readonly SystemDsl _app;

    private bool _executed = false;

    public ScenarioDsl(Channel channel, SystemDsl app)
    {
        _channel = channel;
        _app = app;
    }

    internal Channel Channel => _channel;

    public GivenStage Given()
    {
        EnsureNotExecuted();
        return new GivenStage(_channel, _app, this);
    }

    IGiven IScenarioDsl.Given() => Given();

    public WhenStage When()
    {
        EnsureNotExecuted();
        return new WhenStage(_channel, _app, this);
    }

    IWhen IScenarioDsl.When() => When();

    public void MarkAsExecuted()
    {
        _executed = true;
    }

    private void EnsureNotExecuted()
    {
        if (_executed)
        {
            throw new InvalidOperationException("Scenario has already been executed. " +
                "Each test method should contain only ONE scenario execution (Given-When-Then). " +
                "Split multiple scenarios into separate test methods.");
        }
    }
}

