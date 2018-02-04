using System;
using System.Collections.Generic;
using System.Linq;
using Ponics.Commands;
using Ponics.Kernel.Commands;
using SimpleInjector;

namespace Ponics.Api.CompositionRoot.ToleranceCommands
{
    public abstract class BootstrapToleranceCommands : IBootstrap
    {
        public abstract Type CommandType { get; }
        public abstract Type ToleranceCommandHandlerType { get; }
        public IEnumerable<Type> GetToleranceCommandTypes()
        {
            return from type in CommandType.Assembly.GetExportedTypes()
                let baseType = type.BaseType
                where baseType != null
                where baseType.IsGenericType
                where baseType.GetGenericTypeDefinition() == CommandType
                   where !type.IsAbstract
                select type;
        }

        public void Bootstrap(Container container)
        {
            var commandHandlerType = typeof(ICommandHandler<>);

            foreach (var addToleranceType in GetToleranceCommandTypes())
            {
                var toleranceType = addToleranceType.BaseType.GenericTypeArguments.First();

                var genericCommandHandlerType = commandHandlerType.MakeGenericType(addToleranceType);
                var genericAddToleranceCommandHandlerType = ToleranceCommandHandlerType.MakeGenericType(toleranceType);
                container.Register(genericCommandHandlerType, genericAddToleranceCommandHandlerType);
            }
        }
    }
}
