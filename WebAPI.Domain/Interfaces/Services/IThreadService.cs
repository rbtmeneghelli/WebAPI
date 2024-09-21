namespace WebAPI.Domain.Interfaces.Services;

public interface IThreadService : IDisposable
{
    bool RunMethodWithThreadPool(int value);

    bool RunMethodWithThreadParallel(IEnumerable<int> list);
}
