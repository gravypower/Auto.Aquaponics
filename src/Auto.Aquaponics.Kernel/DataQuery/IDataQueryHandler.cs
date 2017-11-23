namespace Auto.Aquaponics.Kernel.DataQuery
{

    public interface IDataQueryHandler<TQuery, TResult> where TQuery : IDataQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
