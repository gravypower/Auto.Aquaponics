using ServiceStack;

namespace Ponics.Kernel.Queries
{
    public interface IQuery<TResult> : IReturn<TResult>
    {
    }

    public abstract class Query<TResult> : IQuery<TResult>
    {
    }
}