namespace Ponics.Kernel.Queries
{

    public interface IDataQueryHandler<in TQuery, out TResult> 
        where TQuery : IDataQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
