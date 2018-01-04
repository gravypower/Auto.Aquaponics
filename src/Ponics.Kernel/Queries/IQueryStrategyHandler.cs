namespace Ponics.Kernel.Queries
{
    public interface IQueryStrategyHandler<in TQuery, out TResult> 
        where TQuery : IQueryStrategy<TResult>
    {
        TResult Handle(TQuery query);
    }
}
