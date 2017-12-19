using System;
using Ponics.Analysis.Levels.Commands;
using Ponics.Commands;

namespace Ponics.Analysis.Levels.Handlers
{
    public class DeleteToleranceCommandHandler<TTolerance> : ICommandHandler<DeleteTolerance<TTolerance>>
        where TTolerance : Tolerance
    {
        public void Handle(DeleteTolerance<TTolerance> command)
        {
            throw new NotImplementedException();
        }
    }
}
