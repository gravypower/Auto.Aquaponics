using Ponics.Analysis.Levels;
using Ponics.Commands;

namespace Ponics.Api.Tests.CompositionRoot.ToleranceCommands
{
    public abstract class ToleranceCommand<TTolerance> : Command
        where TTolerance : Tolerance
    {
    }
}
