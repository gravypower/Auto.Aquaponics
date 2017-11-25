using Auto.Aquaponics.Kernel.Data;
using MongoDB.Driver;

namespace Auto.Aquaponics.Data.Mongo
{
    public abstract class MongoDataCommandHandler<TDataCommand> : MongoHandler, IDataCommandHandler<TDataCommand> 
        where TDataCommand : IDataCommand
    {  
        protected MongoDataCommandHandler(IMongoDatabase database):base(database){}
        public abstract void Handle(TDataCommand command);
    }
}
