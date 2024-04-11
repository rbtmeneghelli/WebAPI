namespace WebAPI.Application.Interfaces;

public interface IThreadService : IDisposable
{
    bool RunMethodWithThreadPool(int value);

    bool RunMethodWithThreadParallel(List<int> list);
}
