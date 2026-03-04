using Dsl.Port.Background;

namespace Dsl.Port;

public interface IBackgroundDsl
{
    IShould Shop();

    IShould Erp();

    IShould Tax();

    IShould Clock();
}
