using Ponics.Analysis.Levels.Commands;
using Ponics.Commands;

namespace Ponics.Analysis.Levels.Handlers
{
    public class UpdateToleranceCommandHandler<TTolerance> : ICommandHandler<UpdateTolerance<TTolerance>>
        where TTolerance : Tolerance
    {
        public void Handle(UpdateTolerance<TTolerance> command)
        {
            throw new System.NotImplementedException();
        }
    }
}
