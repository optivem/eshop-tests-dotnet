namespace Dsl.Port.Assume;

public interface IAssumeStage
{
    IShould Shop();

    IShould Erp();

    IShould Tax();

    IShould Clock();
}
