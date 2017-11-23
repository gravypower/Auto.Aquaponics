using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Funq;
using ServiceStack;

namespace Auto.Aquaponics.Api
{
    public class AppHost : AppHostBase
    {
        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost()
            : base(
                  "Auto.Aquaponics.Api", 
                  new []{
                      typeof(QueryService).GetAssembly()
                  })
        {
        }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            var sic = Bootstrapper.Bootstrap();
            container.Adapter = new SimpleInjectorIocAdapter(sic);

            var serviceType = GenerateQueryServices(Bootstrapper.GetQueryTypes(), typeof(QueryService));
            RegisterService(serviceType);
        }

        public Type GenerateQueryServices(IEnumerable<QueryInfo> misingRequestTypes,
            Type autoQueryServiceBaseType)
        {
            var assemblyName = new AssemblyName(Guid.NewGuid().ToString());
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule("tmpModule");

            var typeBuilder = moduleBuilder.DefineType(
                "__AutoQueryServices",
                TypeAttributes.Public |
                TypeAttributes.Class,
                autoQueryServiceBaseType);

            foreach (var requestType in misingRequestTypes)
            {
                var genericDef = requestType.QueryType.GetTypeWithGenericTypeDefinitionOf(typeof(Query.IQuery<>));

                if (genericDef == null)
                {
                    continue;
                }

                var method = typeBuilder.DefineMethod("Any",
                    MethodAttributes.Public | MethodAttributes.Virtual,
                    CallingConventions.Standard,
                    requestType.ResultType,
                    new[] {requestType.QueryType});

                var il = method.GetILGenerator();

                var genericArgs = genericDef.GetGenericArguments();
                var mi = autoQueryServiceBaseType.GetMethods()
                    .First(x => x.GetGenericArguments().Length == genericArgs.Length);
                var genericMi = mi.MakeGenericMethod(genericArgs);

                var queryType = typeof(Query.IQuery<>).MakeGenericType(genericArgs);

                il.Emit(OpCodes.Nop);
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Box, queryType);
                il.Emit(OpCodes.Callvirt, genericMi);
                il.Emit(OpCodes.Ret);
            }

            var servicesType = typeBuilder.CreateTypeInfo().AsType();

            return servicesType;
        }
    }
}