using ServiceStack;

namespace Auto.Aquaponics.Query
{
    public interface IQuery<TResult> : IReturn<TResult>
    {
    }
}