using MongoDB.Driver;
using Ponics.Kernel.Commands;

namespace Ponics.Data.Mongo
{
    public abstract class MongoDataCommandHandler<TDataCommand> : MongoHandler, IDataCommandHandler<TDataCommand> 
        where TDataCommand : IDataCommand
    {  
        protected MongoDataCommandHandler(IMongoDatabase database):base(database){}
        public abstract void Handle(TDataCommand command);
    }
}
