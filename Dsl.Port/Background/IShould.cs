namespace Dsl.Port.Background;

public interface IShould
{
    Task<IBackgroundDsl> ShouldBeRunning();
}
