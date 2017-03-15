//using Auto.Aquaponics.Kernel.Persistence;

//namespace Auto.Aquaponics.Kernel.Query.Decorators
//{
//    public class MementoQueryHandlerDecorator<TQuery, TResult> :
//        IQueryHandler<TQuery, TResult>
//        where TQuery : Query<TResult>
//        where TResult : QueryResult
//    {
//        private readonly QueryMemento _queryMemento;
//        public readonly IQueryHandler<TQuery, TResult> Decorated;

//        public MementoQueryHandlerDecorator(QueryMemento queryMemento, IQueryHandler<TQuery, TResult> decorated)
//        {
//            _queryMemento = queryMemento;
//            Decorated = decorated;
//        }

//        public TResult Handle(TQuery query)
//        {
//            _queryMemento.Save(query);
//            return Decorated.Handle(query);
//        }
//    }
//}
