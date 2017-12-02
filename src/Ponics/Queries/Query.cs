using ServiceStack;

namespace Ponics.Queries
{
    public interface IQuery<TResult> : IReturn
    {
    }

    public abstract class Query<TResult> : IQuery<TResult>
    {
    }
}