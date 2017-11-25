using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Auto.Aquaponics.Analysis.Levels;
using SimpleInjector;
using Auto.Aquaponics.AquaponicSystems;
using Auto.Aquaponics.Commands;
using Auto.Aquaponics.HardCodedData;
using Auto.Aquaponics.Kernel.Data;
using Auto.Aquaponics.Organisms;
using Auto.Aquaponics.Queries;

namespace Auto.Aquaponics.Api
{
    public class Bootstrapper
    {
        private static Container _container;
        private static readonly Assembly[] ContractAssemblies = {typeof(Query<>).Assembly};

        public static Container Bootstrap()
        {
            _container = new Container();

            _container.Register<IQueryHandler<GetAllSystems, IList<AquaponicSystem>>, GetAllSystemsHandler>();
            _container.Register<IQueryHandler<GetSystem, AquaponicSystem>, GetSystemHandler>();

            _container.Register<IQueryHandler<GetAllOrganisms, IList<Organism>>, GetAllOrganismsDataQueryHandler>();

            _container.Register(typeof(IQueryHandler<,>), new[] { typeof(IQueryHandler<,>).Assembly });

            var levelMagicStringsAssembly = typeof(ILevelsMagicStrings).Assembly;

            var registrations =
                from type in levelMagicStringsAssembly.GetExportedTypes()
                where typeof(ILevelsMagicStrings).IsAssignableFrom(type)
                where !type.IsAbstract
                select type;

            foreach (var reg in registrations)
            {
                _container.Register(reg.GetInterfaces().Single(i=> i != typeof(ILevelsMagicStrings)), reg);
            }

            _container.Register<IDataQueryHandler<GetAllOrganisms, IList<Organism>>, GetAllOrganismsDataQueryHandler>();

            _container.Verify();

            return _container;
        }

        public static object GetInstance(Type serviceType)
        {
            return _container.GetInstance(serviceType);
        }

        public static IEnumerable<Type> GetCommandTypes() =>
            from assembly in ContractAssemblies
            from type in assembly.GetExportedTypes()
            where typeof(ICommand).IsAssignableFrom(type)
            select type;

        public static IEnumerable<QueryInfo> GetQueryTypes() =>
            from assembly in ContractAssemblies
            from type in assembly.GetExportedTypes()
            where QueryInfo.IsQuery(type) && !type.IsAbstract
            select new QueryInfo(type);

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