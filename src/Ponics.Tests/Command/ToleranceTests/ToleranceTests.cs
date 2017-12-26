using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Ponics.Analysis.Levels.Commands;
using Ponics.Analysis.Levels.Handlers;
using Ponics.Analysis.Levels.MagicStrings;
using Ponics.Kernel.Data;
using Ponics.Organisms;

namespace Ponics.Tests.Command.ToleranceTests
{
    public abstract class ToleranceTests<TTolerance, TToleranceCommand, TToleranceCommandHandler>
        where TToleranceCommandHandler: ToleranceCommandHandler<TTolerance, TToleranceCommand>
        where TToleranceCommand : ToleranceCommand<TTolerance>
        where TTolerance : Analysis.Levels.Tolerance
    {
        protected IDataQueryHandler<GetOrganisms, List<Organisms.Organism>> GetAllOrganismsDataQueryHandler;
        protected Organisms.Organism Organism;
        protected MockTolerance MockTolerance;
        protected IDataCommandHandler<UpdateOrganism> UpdateOrganismDataCommandHandler;
        protected ToleranceMagicStrings ToleranceMagicStrings;

        public TToleranceCommandHandler Sut { get; set; }

        [SetUp]
        public void ToleranceTestsSetUp()
        {
            ToleranceMagicStrings = new ToleranceMagicStrings();

            GetAllOrganismsDataQueryHandler = Substitute.For<IDataQueryHandler<GetOrganisms, List<Organism>>>();
            UpdateOrganismDataCommandHandler = Substitute.For<IDataCommandHandler<UpdateOrganism>>();

            Organism = new Organism
            {
                Id = Guid.NewGuid()
            };

            GetAllOrganismsDataQueryHandler.Handle(Arg.Any<GetOrganisms>()).Returns(new List<Organism> { Organism });

            MockTolerance = new MockTolerance();
        }
    }
}
