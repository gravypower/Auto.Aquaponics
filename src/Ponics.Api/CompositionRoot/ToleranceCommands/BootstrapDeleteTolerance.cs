using System;
using Ponics.Analysis.Levels.Commands;
using Ponics.Analysis.Levels.Handlers;

namespace Ponics.Api.CompositionRoot.ToleranceCommands
{
    public class BootstrapDeleteTolerance : BootstrapToleranceCommands
    {
        public override Type TCommand => typeof(DeleteTolerance<>);
        public override Type TToleranceCommandHandler => typeof(DeleteToleranceCommandHandler<>);
    }
}
