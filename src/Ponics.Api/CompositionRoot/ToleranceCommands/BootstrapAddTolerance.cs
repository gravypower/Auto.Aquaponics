using System;
using Ponics.Analysis.Levels.Commands;
using Ponics.Analysis.Levels.Handlers;

namespace Ponics.Api.CompositionRoot.ToleranceCommands
{
    public class BootstrapUpdateTolerance: BootstrapToleranceCommands
    {
        public override Type TCommand => typeof(UpdateTolerance<>);
        public override Type TToleranceCommandHandler => typeof(UpdateToleranceCommandHandler<>);
    }
}
