using System;
using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Ponics.Analysis.Levels;
using Ponics.Analysis.Levels.Handlers;
using Ponics.Analysis.Levels.MagicStrings;
using Ponics.Kernel.Data;
using Ponics.Organisms;

namespace Ponics.Tests.Query.Level
{
    public abstract class LevelAnalysisTests<TQueryHandler,TMagicStrings,TQuery,TResult, TTolerance>
        where TQuery : AnalyseToleranceQuery<TResult, TTolerance>, new()
        where TResult : ToleranceAnalysis<TTolerance>, new() 
        where TMagicStrings : class, ILevelsMagicStrings
        where TQueryHandler : AnalyseLevelsQueryHandler<TQuery, TResult, TTolerance>
        where TTolerance : Tolerance
    {

        protected const string OrganismNotDefinedExceptionMessage = "Organism not defined";
        protected const string OrganismTolerancesNotDefinedExceptionMessage = "Organism tolerances not defined";

        protected Organism Organism;
        protected IList<Organism> Organisms;
        protected IDataQueryHandler<GetOrganisms, List<Organism>> GetAllOrganismsDataQueryHandler;

        protected TQueryHandler Sut;
        protected TMagicStrings LevelQueryHandlerMagicStrings;

        protected abstract Organism GetOrganism();
        protected abstract IEnumerable<double> Is_suitable_cases();
        protected abstract IEnumerable<double> Is_not_suitable_cases();
        protected abstract IEnumerable<double> Is_not_ideal_cases();
        protected abstract IEnumerable<double> Is_ideal_cases();

        protected abstract void DoSetUp();

        [SetUp]
        public void SetUp()
        {
            Organism = GetOrganism();
            Organisms = new List<Organism> {Organism};
            GetAllOrganismsDataQueryHandler = Substitute.For<IDataQueryHandler<GetOrganisms, List<Organism>>>();
            GetAllOrganismsDataQueryHandler.Handle(Arg.Any<GetOrganisms>()).Returns(Organisms);
            LevelQueryHandlerMagicStrings = Substitute.For<TMagicStrings>();
            LevelQueryHandlerMagicStrings.OrganismNotDefined.Returns(OrganismNotDefinedExceptionMessage);
            LevelQueryHandlerMagicStrings.OrganismTolerancesNotDefined.Returns(OrganismTolerancesNotDefinedExceptionMessage);
            DoSetUp();
        }

        [Test]
        public void Organism_not_defined_ArgumentNullException_thrown()
        {
            var query = new TQuery();
            void Act() => Sut.Handle(query);
            AssertArgumentNullException(Act, OrganismNotDefinedExceptionMessage, nameof(Organism));
        }

        [Test]
        public void Tolerances_not_defined_ArgumentNullException_thrown()
        {
            var organism = new Organism{Id = Guid.NewGuid(), Name = ""};
            Organisms.Add(organism);
            var query = new TQuery {OrganismId = organism.Id};

            void Act() => Sut.Handle(query);
            AssertArgumentNullException(Act, OrganismTolerancesNotDefinedExceptionMessage, nameof(organism.Tolerances));
        }

        [Test]
        public void Is_suitable()
        {
            foreach (var isSuitableCase in Is_suitable_cases())
            {
                var query = new TQuery
                {
                    OrganismId = Organism.Id,
                    Value = isSuitableCase
                };
                var result = Sut.Handle(query);
                result.SutablalForOrganism.Should().BeTrue();
            }
        }

        [Test]
        public void Is_not_suitable()
        {
            foreach (var isNotSuitableCase in Is_not_suitable_cases())
            {
                var query = new TQuery
                {
                    OrganismId = Organism.Id,
                    Value =  isNotSuitableCase
                };

                var result = Sut.Handle(query);
                result.SutablalForOrganism.Should().BeFalse();
            }
        }
        
        [Test]
        public void Is_not_ideal()
        {
            foreach (var isNotIdealCase in Is_not_ideal_cases())
            {
                var query = new TQuery
                {
                    OrganismId = Organism.Id,
                    Value = isNotIdealCase
                };

                var result = Sut.Handle(query);
                result.IdealForOrganism.Should().BeFalse();
            }
        }

        [Test]
        public void Is_ideal()
        {
            foreach (var isIdealCase in Is_ideal_cases())
            {
                var query = new TQuery
                {
                    OrganismId = Organism.Id,
                    Value = isIdealCase
                };

                var result = Sut.Handle(query);
                result.IdealForOrganism.Should().BeTrue();
            }
        }

        protected static void AssertArgumentNullException(Action act, string message, string paramName)
        {
            act.ShouldThrow<ArgumentNullException>()
                .WithMessage($"{message}\r\nParameter name: {paramName}");
        }
    }
}
