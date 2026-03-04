namespace Dsl.Port.Assume;

public interface IShould
{
    Task<IAssumeStage> ShouldBeRunning();
}
