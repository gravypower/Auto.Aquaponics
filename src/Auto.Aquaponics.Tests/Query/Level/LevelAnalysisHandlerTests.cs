using System;
using System.Collections.Generic;
using System.Linq;
using Auto.Aquaponics.Analysis.Level;
using Auto.Aquaponics.Kernel.DataQuery;
using Auto.Aquaponics.Organisms;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Auto.Aquaponics.Tests.Query.Level
{
    public abstract class LevelAnalysisHandlerTests<TQueryHandler,TMagicStrings,TQuery,TResult>
        where TQuery : LevelAnalysisQuery<TResult>, new()
        where TResult : LevelAnalysis, new() 
        where TMagicStrings : class, ILevelMagicStrings
        where TQueryHandler : LevelAnalysisQueryHandler<TQuery, TResult>
    {

        protected const string OrganismNotDefinedExceptionMessage = "Organism not defined";
        protected const string OrganismTolerancesNotDefinedExceptionMessage = "Organism tolerances not defined";

        protected Organism Organism;
        protected IList<Organism> Organisms = new List<Organism>();
        protected IDataQueryHandler<GetAllOrganisms, IList<Organism>> GetAllOrganismsDataQueryHandler;

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
            Organisms.Add(Organism);
            GetAllOrganismsDataQueryHandler = Substitute.For<IDataQueryHandler<GetAllOrganisms, IList<Organism>>>();
            GetAllOrganismsDataQueryHandler.Handle(Arg.Any<GetAllOrganisms>()).Returns(Organisms);
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
            var organism = new Organism(Guid.NewGuid(), "");
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
