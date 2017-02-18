namespace Auto.Aquaponics.Kernel.Query
{
    public interface IQueryHandler<in TQuery, out TResult>
    {
        TResult Handle(TQuery query);
    }
}