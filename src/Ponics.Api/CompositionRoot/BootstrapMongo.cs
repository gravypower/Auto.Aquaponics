using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using Ponics.Analysis.Levels;
using Ponics.Authentication.User;
using Ponics.Data.Mongo;
using Ponics.Data.Mongo.Serializers;
using Ponics.Kernel.Commands;
using Ponics.Kernel.Queries;
using Ponics.Organisms;
using Ponics.Organisms.Tolerances;
using SimpleInjector;

namespace Ponics.Api.CompositionRoot
{
    public class BootstrapMongo:IBootstrap
    {
        private static readonly Assembly[] ContractAssemblies = { typeof(MongoContract).Assembly };
        public void Bootstrap(Container container)
        {
            var mongodbUri = Environment.GetEnvironmentVariable("MONGODB_URI");

            var mongoUrl = new MongoUrl(mongodbUri);
            var dbname = mongoUrl.DatabaseName;
            var db = new MongoClient(mongoUrl).GetDatabase(dbname);
            container.Register(() => db, Lifestyle.Singleton);

            BsonClassMap.RegisterClassMap<PonicsSystem>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(c => c.Id).SetIdGenerator(CombGuidGenerator.Instance);
            });

            BsonClassMap.RegisterClassMap<Organism>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(c => c.Id).SetIdGenerator(CombGuidGenerator.Instance);
            });

            BsonClassMap.RegisterClassMap<User>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(c => c.Id).SetIdGenerator(CombGuidGenerator.Instance);
            });

            BsonClassMap.RegisterClassMap<LevelReading>(cm =>
            {
                cm.AutoMap();
                cm.GetMemberMap(c => c.DateTime).SetSerializer(ZonedDateTimeSerializer.Instance);
            });


            foreach (var toleranceType in GetToleranceTypes())
            {
                var bsonClassMap = new BsonClassMap(toleranceType);
                BsonClassMap.RegisterClassMap(bsonClassMap);
            }

            container.Register(typeof(IDataQueryHandler<,>), ContractAssemblies);
            container.Register(typeof(IDataCommandHandler<>), ContractAssemblies);
        }

        public static IEnumerable<Type> GetToleranceTypes() =>
            from type in typeof(Tolerance).Assembly.GetExportedTypes()
            where typeof(Tolerance).IsAssignableFrom(type)
            where !type.IsAbstract
            select type;
    }
}
