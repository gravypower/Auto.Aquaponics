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
        public AppHost() : base("Auto.Aquaponics.Api", typeof(QueryService).Assembly)
        {
        }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            Plugins.Add(new PostmanFeature());

            var sic = Bootstrapper.Bootstrap();
            container.Adapter = new SimpleInjectorIocAdapter(sic);

            var assemblyName = new AssemblyName(Guid.NewGuid().ToString());
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule("tmpModule");
            
            var queryServiceType = GenerateQueryServices(Bootstrapper.GetQueryTypes(), typeof(QueryService), moduleBuilder);
            RegisterService(queryServiceType);
            
            var commandSserviceType = GenerateCommandServices(Bootstrapper.GetCommandTypes(), typeof(CommandService), moduleBuilder);
            RegisterService(commandSserviceType);
        }
        
        private static Type GenerateCommandServices(IEnumerable<Type> commandTypes, Type autoQueryServiceBaseType, ModuleBuilder moduleBuilder)
        {
            var typeBuilder = moduleBuilder.DefineType(
                "__AutoCommandServices",
                TypeAttributes.Public |
                TypeAttributes.Class,
                autoQueryServiceBaseType);

            foreach (var commandType in commandTypes)
            {
                var method = typeBuilder.DefineMethod("Any",
                    MethodAttributes.Public | MethodAttributes.Virtual,
                    CallingConventions.Standard,
                    null,
                    new[] {commandType});


                var il = method.GetILGenerator();

                var mi = autoQueryServiceBaseType.GetMethods().First();
                var genericMi = mi.MakeGenericMethod(commandType);

                il.Emit(OpCodes.Nop);
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Box, commandType);
                il.Emit(OpCodes.Callvirt, genericMi);
                il.Emit(OpCodes.Ret);
            }

            var servicesType = typeBuilder.CreateTypeInfo().AsType();

            return servicesType;
        }

        private static Type GenerateQueryServices(IEnumerable<QueryInfo> queryTypes, Type autoQueryServiceBaseType, ModuleBuilder moduleBuilder)
        {
            var typeBuilder = moduleBuilder.DefineType(
                "__AutoQueryServices",
                TypeAttributes.Public |
                TypeAttributes.Class,
                autoQueryServiceBaseType);

            foreach (var queryInfo in queryTypes)
            {
                var method = typeBuilder.DefineMethod("Any",
                    MethodAttributes.Public | MethodAttributes.Virtual,
                    CallingConventions.Standard,
                    queryInfo.ResultType,
                    new[] {queryInfo.QueryType});


                var il = method.GetILGenerator();

                var mi = autoQueryServiceBaseType.GetMethods().First();
                var genericMi = mi.MakeGenericMethod(queryInfo.QueryType, queryInfo.ResultType);

                il.Emit(OpCodes.Nop);
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Box, queryInfo.QueryType);
                il.Emit(OpCodes.Callvirt, genericMi);
                il.Emit(OpCodes.Ret);
            }

            var servicesType = typeBuilder.CreateTypeInfo().AsType();

            return servicesType;
        }
    }
}