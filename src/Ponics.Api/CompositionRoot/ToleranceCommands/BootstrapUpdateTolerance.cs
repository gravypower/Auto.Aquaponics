using System;
using Ponics.Analysis.Levels.Commands;
using Ponics.Analysis.Levels.Handlers;

namespace Ponics.Api.CompositionRoot.ToleranceCommands
{
    public class BootstrapAddTolerance: BootstrapToleranceCommands
    {
        public override Type TCommand => typeof(AddTolerance<>);
        public override Type TToleranceCommandHandler => typeof(AddToleranceCommandHandler<>);
    }
}
