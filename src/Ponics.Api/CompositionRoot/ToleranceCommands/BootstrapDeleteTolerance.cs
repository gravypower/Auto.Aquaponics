using System;
using Ponics.Analysis.Levels.Commands;
using Ponics.Analysis.Levels.Handlers;

namespace Ponics.Api.CompositionRoot.ToleranceCommands
{
    public class BootstrapDeleteTolerance : BootstrapToleranceCommands
    {
        public override Type CommandType => typeof(DeleteTolerance<>);
        public override Type ToleranceCommandHandlerType => typeof(DeleteToleranceCommandHandler<>);
    }
}
