using ServiceStack;

namespace Auto.Aquaponics.Queries
{
    public interface IQuery<TResult> : IReturn
    {
    }

    public abstract class Query<TResult> : IQuery<TResult>
    {
    }
}