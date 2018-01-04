using ServiceStack;

namespace Ponics.Kernel.Queries
{
    public interface IQuery<TResult> : IReturn<TResult>
    {
    }
}