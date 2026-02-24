using Optivem.Testing;

namespace DslImpl.Gherkin
{
    public class BaseClause
    {
        internal Channel Channel { get; }

        public BaseClause(Channel channel)
        {
            Channel = channel;
        }
    }
}
