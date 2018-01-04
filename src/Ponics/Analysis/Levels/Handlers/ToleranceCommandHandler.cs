using System;
using System.Collections.Generic;
using System.Linq;
using Ponics.Analysis.Levels.Commands;
using Ponics.Analysis.Levels.MagicStrings;
using Ponics.Commands;
using Ponics.Kernel.Commands;
using Ponics.Kernel.Data;
using Ponics.Organisms;

namespace Ponics.Analysis.Levels.Handlers
{
    public abstract class ToleranceCommandHandler<TTolerance, TToleranceCommand> : ICommandHandler<TToleranceCommand>
        where TToleranceCommand : ToleranceCommand<TTolerance>
        where TTolerance : Tolerance
    {
        protected readonly IDataQueryHandler<GetOrganisms, List<Organism>> GetAllOrganismsDataQueryHandler;
        protected readonly IDataCommandHandler<UpdateOrganism> UpdateOrganismDataCommandHandler;
        protected readonly IToleranceMagicStrings ToleranceMagicStrings;

        protected ToleranceCommandHandler(
            IDataQueryHandler<GetOrganisms, List<Organism>> getAllOrganismsDataQueryHandler,
            IDataCommandHandler<UpdateOrganism> updateOrganismDataCommandHandler,
            IToleranceMagicStrings toleranceMagicStrings)
        {
            GetAllOrganismsDataQueryHandler = getAllOrganismsDataQueryHandler;
            UpdateOrganismDataCommandHandler = updateOrganismDataCommandHandler;
            ToleranceMagicStrings = toleranceMagicStrings;
        }


        public void Handle(TToleranceCommand command)
        {
            var organisms = GetAllOrganismsDataQueryHandler.Handle(new GetOrganisms());
            var organism = organisms.Single(o => o.Id == command.OrganismId);

            DoHandle(command, organism);

            UpdateOrganismDataCommandHandler.Handle(new UpdateOrganism
            {
                OrganismId = organism.Id,
                Organism = organism
            });
        }

        public abstract void DoHandle(TToleranceCommand command, Organism organism);
    }
}
