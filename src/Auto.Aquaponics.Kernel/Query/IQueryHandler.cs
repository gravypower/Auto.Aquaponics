namespace Auto.Aquaponics.Kernel.Query
{
    public interface IQueryHandler<in TQuery, out TResult>
        where TQuery : Query<TResult> 
        where TResult : QueryResult
    {
        TResult Handle(TQuery query);
    }
}