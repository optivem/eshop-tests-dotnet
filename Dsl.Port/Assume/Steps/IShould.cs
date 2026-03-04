using Dsl.Port.Assume;

namespace Dsl.Port.Assume.Steps;

public interface IShould
{
    Task<IAssumeStage> ShouldBeRunning();
}
