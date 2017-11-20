using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using SimpleInjector;
using Auto.Aquaponics.AquaponicSystems;
using Auto.Aquaponics.HardCodedData;
using Auto.Aquaponics.Query;

namespace Auto.Aquaponics.Api
{
    public class Bootstrapper
    {
        private static Container _container;
        private static Assembly[] contractAssemblies = new[] { typeof(IQuery<>).Assembly };

        public static Container Bootstrap()
        {
            _container = new Container();
            _container.Register<IQueryHandler<GetSystems, IList<AquaponicSystem>>, GetSystemsHandler>();
            _container.Verify();

            return _container;
        }

        public static object GetInstance(Type serviceType)
        {
            return _container.GetInstance(serviceType);
        }

        public static IEnumerable<Type> GetCommandTypes() =>
            from assembly in contractAssemblies
            from type in assembly.GetExportedTypes()
            where type.Name.EndsWith("Command")
            select type;

        public static IEnumerable<QueryInfo> GetQueryTypes() =>
            from assembly in contractAssemblies
            from type in assembly.GetExportedTypes()
            where QueryInfo.IsQuery(type)
            select new QueryInfo(type);

        public static IQueryHandler<TQuery, TResult> GetQueryHandler<TQuery, TResult>() where TQuery : IQuery<TResult> =>
            _container.GetInstance(CreateQueryHandlerType<TQuery, TResult>()) as IQueryHandler<TQuery, TResult>;

        private static Type CreateQueryHandlerType<TQuery, TResult>() =>
            typeof(IQueryHandler<,>).MakeGenericType(typeof(TQuery), typeof(TResult));
    }

    [DebuggerDisplay("{QueryType.Name,nq}")]
    public sealed class QueryInfo
    {
        public readonly Type QueryType;
        public readonly Type ResultType;

        public QueryInfo(Type queryType)
        {
            this.QueryType = queryType;
            this.ResultType = DetermineResultTypes(queryType).Single();
        }

        public static bool IsQuery(Type type) => DetermineResultTypes(type).Any();

        private static IEnumerable<Type> DetermineResultTypes(Type type) =>
            from interfaceType in type.GetInterfaces()
            where interfaceType.IsGenericType
            where interfaceType.GetGenericTypeDefinition() == typeof(IQuery<>)
            select interfaceType.GetGenericArguments()[0];
    }
}
