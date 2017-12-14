using System;
using System.Collections.Generic;
using System.Linq;
using Ponics.Analysis.Levels;
using Ponics.Commands;
using Ponics.Kernel;
using SimpleInjector;

namespace Ponics.Api.CompositionRoot
{
    public class BootstrapAddTolerance:IBootstrap
    {
        public void Bootstrap(Container container)
        {
            var commandHandlerType = typeof(ICommandHandler<>);
            var addToleranceCommandHandlerType = typeof(AddToleranceCommandHandler<>);

            foreach (var addToleranceType in GetAddToleranceTypes())
            {
                var toleranceType = addToleranceType.BaseType.GenericTypeArguments[0];

                var gernicCommandHandlerType = commandHandlerType.MakeGenericType(addToleranceType);
                var genericAddToleranceCommandHandlerType = addToleranceCommandHandlerType.MakeGenericType(toleranceType);
                container.Register(gernicCommandHandlerType, genericAddToleranceCommandHandlerType);
            }
        }

        public static IEnumerable<Type> GetAddToleranceTypes() =>
            from type in typeof(AddTolerance<>).Assembly.GetExportedTypes()
            let baseType = type.BaseType
            where baseType != null
            where baseType.IsGenericType
            where baseType.GetGenericTypeDefinition() == typeof(AddTolerance<>)
            where !type.IsAbstract
            select type;
    }
}
