using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Auto.Aquaponics.Analysis.Levels;
using Auto.Aquaponics.AquaponicSystems;
using SimpleInjector;
using Auto.Aquaponics.Commands;
using Auto.Aquaponics.Data.Decorator;
using Auto.Aquaponics.Data.Mongo.CommandHandlers;
using Auto.Aquaponics.Data.Mongo.QueryHandlers;
using Auto.Aquaponics.Data.Seed;
using Auto.Aquaponics.Kernel.Data;
using Auto.Aquaponics.Organisms;
using Auto.Aquaponics.Queries;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;

namespace Auto.Aquaponics.Api
{
    public static class Bootstrapper
    {
        private static Container _container;
        private static readonly Assembly[] ContractAssemblies = {typeof(Query<>).Assembly};

        public static Container Bootstrap()
        {
            _container = new Container();

            RegisterMongo();
            RegisterLevelsMagicStrings();

            RegisterQueryHandlers();
            RegisterDataQueryHandlers();

            _container.Register(typeof(SeedData<>), new[] { typeof(SeedData<>).Assembly });

            _container.Register<
                IDataCommandHandler<AddOrganism>,
                AddOrganismDataCommandHandler>();

            var toleranceAssembly = typeof(Tolerance).Assembly;

            var registrations =
                from type in toleranceAssembly.GetExportedTypes()
                where typeof(Tolerance).IsAssignableFrom(type)
                where !type.IsAbstract
                select type;

            //var addToleranceCommandHandler = typeof(AddToleranceCommandHandler<>);
            

            //foreach (var registration in registrations)
            //{
            //    var typeArgs = [] { registration };
            //    var makeme = d1.MakeGenericType(typeArgs);
            //    object o = Activator.CreateInstance(makeme);
            //}

            _container.RegisterDecorator(
                typeof(IDataQueryHandler<GetAllOrganisms, IList<Organism>>), 
                typeof(SeedOrganismsDecorator));

            _container.Verify();

            return _container;
        }

        private static void RegisterDataQueryHandlers()
        {
            _container.Register<
                IDataQueryHandler<GetAllOrganisms, IList<Organism>>, 
                GetAllOrganismsDataQueryHandler>();

            _container.Register<
                IDataQueryHandler<GetAllSystems, IList<AquaponicSystem>>, 
                GetAllSystemsHandlerDataQueryHandler>();
        }

        private static void RegisterQueryHandlers()
        {
            _container.Register(typeof(IQueryHandler<,>), new[] {typeof(IQueryHandler<,>).Assembly});
        }

        private static void RegisterMongo()
        {
            var mongodbUri = Environment.GetEnvironmentVariable("MONGODB_URI");

            var mongoUrl = new MongoUrl(mongodbUri);
            var dbname = mongoUrl.DatabaseName;
            var db = new MongoClient(mongoUrl).GetDatabase(dbname);
            _container.Register(() => db, Lifestyle.Singleton);

            BsonClassMap.RegisterClassMap<Organism>(cm => 
            {
                cm.AutoMap();
                cm.MapIdMember(c => c.Id).SetIdGenerator(CombGuidGenerator.Instance);
                cm.UnmapProperty(c=>c.Tolerances);
            });
        }

        private static void RegisterLevelsMagicStrings()
        {
            var levelMagicStringsAssembly = typeof(ILevelsMagicStrings).Assembly;

            var registrations =
                from type in levelMagicStringsAssembly.GetExportedTypes()
                where typeof(ILevelsMagicStrings).IsAssignableFrom(type)
                where !type.IsAbstract
                select type;

            foreach (var reg in registrations)
            {
                _container.Register(reg.GetInterfaces().Single(i => i != typeof(ILevelsMagicStrings)), reg);
            }
        }

        public static object GetInstance(Type serviceType)
        {
            return _container.GetInstance(serviceType);
        }

        public static IEnumerable<Type> GetCommandTypes() =>
            from assembly in ContractAssemblies
            from type in assembly.GetExportedTypes()
            where typeof(Command).IsAssignableFrom(type) && !type.IsAbstract
            select type;

        public static IEnumerable<QueryInfo> GetQueryTypes() =>
            from assembly in ContractAssemblies
            from type in assembly.GetExportedTypes()
            where QueryInfo.IsQuery(type) && !type.IsAbstract
            select new QueryInfo(type);
        
        public static object GetCommandHandler(Type commandType) =>
            _container.GetInstance(typeof(ICommandHandler<>).MakeGenericType(commandType));
        
        public static object GetQueryHandler(Type queryType) =>
            _container.GetInstance(CreateQueryHandlerType(queryType));

        private static Type CreateQueryHandlerType(Type queryType) =>
            typeof(IQueryHandler<,>).MakeGenericType(queryType, new QueryInfo(queryType).ResultType);
    }

    [DebuggerDisplay("{QueryType.Name,nq}")]
    public sealed class QueryInfo
    {
        public readonly Type QueryType;
        public readonly Type ResultType;

        public QueryInfo(Type queryType)
        {
            QueryType = queryType;
            ResultType = DetermineResultTypes(queryType).Single();
        }

        public static bool IsQuery(Type type) => DetermineResultTypes(type).Any();

        private static IEnumerable<Type> DetermineResultTypes(Type type) =>
            from interfaceType in type.GetInterfaces()
            where interfaceType.IsGenericType
            where interfaceType.GetGenericTypeDefinition() == typeof(IQuery<>)
            select interfaceType.GetGenericArguments()[0];
    }
}