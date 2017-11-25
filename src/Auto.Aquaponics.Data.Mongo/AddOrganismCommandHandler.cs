using System;
using Auto.Aquaponics.Kernel.Data;
using Auto.Aquaponics.Organisms;
using MongoDB.Driver;

namespace Auto.Aquaponics.Data.Mongo
{
    public class AddOrganismCommandHandler : IDataCommandHandler<AddOrganism>
    {
        protected IMongoClient Client;
        protected IMongoDatabase Database;

        public AddOrganismCommandHandler(string mongodbUri, string databaseName)
        {
            var mongoUri = new MongoUrl(mongodbUri);
            Client = new MongoClient(mongoUri);
            Database = Client.GetDatabase(databaseName);
        }

        public void Handle(AddOrganism command)
        {
            var organisms = Database.GetCollection<Organism>(nameof(Organism));
            organisms.InsertOne(command.Organism);
        }
    }
}
