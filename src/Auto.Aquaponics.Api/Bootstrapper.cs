using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Auto.Aquaponics.Analysis.Level;
using SimpleInjector;
using Auto.Aquaponics.AquaponicSystems;
using Auto.Aquaponics.HardCodedData;
using Auto.Aquaponics.Query;

namespace Auto.Aquaponics.Api
{
    public class Bootstrapper
    {
        private static Container _container;
        private static readonly Assembly[] ContractAssemblies = {typeof(IQuery<>).Assembly};

        public static Container Bootstrap()
        {
            _container = new Container();
            _container.Register<IQueryHandler<GetAllSystems, IList<AquaponicSystem>>, GetAllSystemsHandler>();
            _container.Register<IQueryHandler<GetSystem, AquaponicSystem>, GetSystemHandler>();

            _container.Register(typeof(LevelAnalysisQueryHandler<,>), new[] { typeof(LevelAnalysisQueryHandler<,>).Assembly });
            _container.Register(typeof(ILevelMagicStrings), new[] { typeof(ILevelMagicStrings).Assembly });

            var levelMagicStringsAssembly = typeof(ILevelMagicStrings).Assembly;

            var registrations =
                from type in levelMagicStringsAssembly.GetExportedTypes()
                where type.GetInterfaces().Any()
                select new { Service = type.GetInterfaces().Single(), Implementation = type };

            foreach (var reg in registrations)
            {
                _container.Register(reg.Service, reg.Implementation);
            }


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
            where type.Name.EndsWith("Command")
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