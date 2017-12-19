using System;
using System.Collections.Generic;
using System.Linq;
using Ponics.Commands;
using SimpleInjector;

namespace Ponics.Api.CompositionRoot.ToleranceCommands
{
    public abstract class BootstrapToleranceCommands : IBootstrap
    {
        public abstract Type TCommand { get; }
        public abstract Type TToleranceCommandHandler { get; }
        public IEnumerable<Type> GetToleranceCommandTypes()
        {
            return from type in TCommand.Assembly.GetExportedTypes()
                let baseType = type.BaseType
                where baseType != null
                where baseType.IsGenericType
                where baseType.GetGenericTypeDefinition() == TCommand
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
                var genericAddToleranceCommandHandlerType = TToleranceCommandHandler.MakeGenericType(toleranceType);
                container.Register(genericCommandHandlerType, genericAddToleranceCommandHandlerType);
            }
        }
    }
}
