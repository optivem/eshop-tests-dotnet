namespace Dsl.Port;

public interface IFeatureDsl
{
    IBackgroundDsl Background();

    IScenarioDsl Scenario();
}
