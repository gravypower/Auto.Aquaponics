using System;
using Ponics.Analysis.Levels.Commands;
using Ponics.Analysis.Levels.Handlers;

namespace Ponics.Api.CompositionRoot.ToleranceCommands
{
    public class BootstrapAddTolerance: BootstrapToleranceCommands
    {
        public override Type CommandType => typeof(AddTolerance<>);
        public override Type ToleranceCommandHandlerType => typeof(AddToleranceCommandHandler<>);
    }
}
