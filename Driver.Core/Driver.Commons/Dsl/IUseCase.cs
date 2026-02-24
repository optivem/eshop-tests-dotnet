namespace Driver.Core.Commons.Dsl;

public interface IUseCase<T>
{
    T Execute();
}
