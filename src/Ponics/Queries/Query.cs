using ServiceStack;

namespace Ponics.Queries
{
    public interface IQuery<TResult> : IReturn<TResult>
    {
    }

    public abstract class Query<TResult> : IQuery<TResult>
    {
    }
}