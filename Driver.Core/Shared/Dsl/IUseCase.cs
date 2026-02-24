namespace Driver.Shared.Dsl;

public interface IUseCase<T>
{
    T Execute();
}
