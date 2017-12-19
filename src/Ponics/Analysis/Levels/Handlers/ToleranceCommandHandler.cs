using System;
using System.Collections.Generic;
using System.Linq;
using Ponics.Analysis.Levels.Commands;
using Ponics.Analysis.Levels.MagicStrings;
using Ponics.Commands;
using Ponics.Kernel.Data;
using Ponics.Organisms;

namespace Ponics.Analysis.Levels.Handlers
{
    public abstract class ToleranceCommandHandler<TTolerance, TToleranceCommand> : ICommandHandler<TToleranceCommand>
        where TToleranceCommand : ToleranceCommand<TTolerance>
        where TTolerance : Tolerance
    {
        protected readonly IDataQueryHandler<GetAllOrganisms, List<Organism>> GetAllOrganismsDataQueryHandler;
        protected readonly IDataCommandHandler<UpdateOrganism> UpdateOrganismDataCommandHandler;
        protected readonly IToleranceMagicStrings ToleranceMagicStrings;

        protected ToleranceCommandHandler(
            IDataQueryHandler<GetAllOrganisms, List<Organism>> getAllOrganismsDataQueryHandler,
            IDataCommandHandler<UpdateOrganism> updateOrganismDataCommandHandler,
            IToleranceMagicStrings toleranceMagicStrings)
        {
            GetAllOrganismsDataQueryHandler = getAllOrganismsDataQueryHandler;
            UpdateOrganismDataCommandHandler = updateOrganismDataCommandHandler;
            ToleranceMagicStrings = toleranceMagicStrings;
        }


        public void Handle(TToleranceCommand command)
        {
            var organisms = GetAllOrganismsDataQueryHandler.Handle(new GetAllOrganisms());
            var organism = organisms.Single(o => o.Id == command.OrganismId);

            DoHandle(command, organism);

            UpdateOrganismDataCommandHandler.Handle(new UpdateOrganism
            {
                Id = organism.Id,
                Organism = organism
            });
        }

        public abstract void DoHandle(TToleranceCommand command, Organism organism);
    }
}
