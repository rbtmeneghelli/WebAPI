namespace WebAPI.Application.Services.NfService;

public abstract class GenericNfService<TResult> where TResult : class
{
    protected GenericNfService()
    {
        
    }

    protected abstract IEnumerable<TResult> ReadNf();
}
