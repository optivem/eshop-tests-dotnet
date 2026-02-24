namespace Driver.Core.Driver.Shared.Dsl;

public interface IUseCase<T>
{
    T Execute();
}
