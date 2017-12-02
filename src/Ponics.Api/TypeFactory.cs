using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace Ponics.Api
{
    public static class TypeFactory
    {
        private static readonly AssemblyName AssemblyName;
        private static readonly AssemblyBuilder AssemblyBuilder;
        private static readonly ModuleBuilder ModuleBuilder;

        static TypeFactory()
        {

            AssemblyName = new AssemblyName(Guid.NewGuid().ToString());
            AssemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(AssemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder = AssemblyBuilder.DefineDynamicModule("tmpModule");
        }

        public static Type GenerateCommandServices(IEnumerable<Type> commandTypes, Type autoQueryServiceBaseType)
        {
            var typeBuilder = ModuleBuilder.DefineType(
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
                    new[] { commandType });


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

        public static Type GenerateQueryServices(IEnumerable<QueryInfo> queryTypes, Type autoQueryServiceBaseType)
        {
            var typeBuilder = ModuleBuilder.DefineType(
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
                    new[] { queryInfo.QueryType });


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
