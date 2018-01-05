using System;
using Ponics.Analysis.Levels;
using Ponics.Commands;
using Ponics.Kernel.Commands;
using Ponics.Organisms.Tolerances;

namespace Ponics.Api.Tests.CompositionRoot.ToleranceCommands
{
    public class ToleranceCommandHandler<TTolerance> : ICommandHandler<ToleranceCommand<TTolerance>>
        where TTolerance : Tolerance
    {
        public void Handle(ToleranceCommand<TTolerance> command)
        {
            throw new NotImplementedException();
        }
    }
}
