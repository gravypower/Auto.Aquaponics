namespace Ponics.Kernel.Data
{

    public interface IDataQueryHandler<in TQuery, out TResult> where TQuery : IDataQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
