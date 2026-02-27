using Driver.Core;
using Optivem.Testing;

namespace Dsl.Core.Scenario
{
    public class ScenarioDslFactory
    {
        private readonly SystemDsl _app;

        public ScenarioDslFactory(SystemDsl app)
        {
            _app = app;
        }

        public ScenarioDsl Create(Channel channel) { return new ScenarioDsl(channel, _app); }
    }
}


