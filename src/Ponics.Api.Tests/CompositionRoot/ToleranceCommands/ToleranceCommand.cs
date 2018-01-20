using Ponics.Analysis.Levels;
using Ponics.Commands;
using Ponics.Kernel.Commands;
using Ponics.Organisms.Tolerances;

namespace Ponics.Api.Tests.CompositionRoot.ToleranceCommands
{
    public abstract class ToleranceCommand<TTolerance> : ICommand
        where TTolerance : Tolerance
    {
    }
}
