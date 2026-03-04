namespace Dsl.Port.Assume;

using Dsl.Port.Assume.Steps;

public interface IAssumeStage
{
    IShould Shop();

    IShould Erp();

    IShould Tax();

    IShould Clock();
}
