using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Ponics.Analysis;
using Ponics.Analysis.Levels.Handlers;
using Ponics.Api.Auth;
using Ponics.Kernel.Commands;
using Ponics.Kernel.Pipelines;
using Ponics.Kernel.Queries;
using SimpleInjector;

namespace Ponics.Api.CompositionRoot
{
    public static class Bootstrapper
    {
        private static Container _container;
        private static readonly Assembly[] ContractAssemblies =
        {
            typeof(PonicsContract).Assembly,
            typeof(PonicsAnalysisContract).Assembly
        };
        private static readonly Assembly[] BootstrapAssemblies = { typeof(IBootstrap).Assembly };

        public static Container Bootstrap(IApplicationBuilder app)
        {
            _container = new Container();

            foreach (var bootstrapType in GetBootstrapTypes())
            {
                var bootstrap = (IBootstrap)Activator.CreateInstance(bootstrapType);
                bootstrap.Bootstrap(_container);
            }

            _container.Register(typeof(IQueryHandler<,>), ContractAssemblies);
            _container.Register(typeof(IQueryStrategyHandler<,>), ContractAssemblies);

            _container.Register(typeof(ICommandHandler<>), ContractAssemblies);


            _container.RegisterCollection(typeof(IAnalyseLevelsQueryHandler), ContractAssemblies);

            _container.Register(typeof(Pipeline<,,>), ContractAssemblies);
            _container.RegisterCollection(typeof(Node<,>), ContractAssemblies);

            
#if DEBUG
            _container.Verify(VerificationOption.VerifyAndDiagnose);
#else
            _container.Verify();
#endif

            _container.Register<IHttpContextAccessor>(() => app.ApplicationServices.GetService<IHttpContextAccessor>());
            _container.Register<Context>();

            return _container;
        }

        public static object GetInstance(Type serviceType)
        {
            return _container.GetInstance(serviceType);
        }

        public static IEnumerable<Type> GetBootstrapTypes() =>
            from assembly in BootstrapAssemblies
            from type in assembly.GetExportedTypes()
            where typeof(IBootstrap).IsAssignableFrom(type) && !type.IsAbstract
            select type;

        public static IEnumerable<Type> GetCommandTypes() =>
            from assembly in ContractAssemblies
            from type in assembly.GetExportedTypes()
            where typeof(ICommand).IsAssignableFrom(type) && !type.IsAbstract
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