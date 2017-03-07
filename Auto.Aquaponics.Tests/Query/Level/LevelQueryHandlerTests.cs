using System;
using System.Collections.Generic;
using Auto.Aquaponics.Organisms;
using Auto.Aquaponics.Query.LevelAnalysis;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Auto.Aquaponics.Tests.Query.Level
{
    public abstract class LevelQueryHandlerTests
        <
        TLevelQueryHandler,
        TILevelQueryHandlerMagicStrings,
        TQuery, 
        TResult
        >
        where TQuery : LevelAnalysisQuery, new() where TResult : LevelAnalysisResult, new() where TILevelQueryHandlerMagicStrings : class, ILevelQueryHandlerMagicStrings
        where TLevelQueryHandler : LevelQueryHandler<TQuery, TResult>
    {

        protected const string OrganismNotDefinedExceptionMessage = "Organism not defined";
        protected const string OrganismTolerancesNotDefinedExceptionMessage = "Organism tolerances not defined";

        protected Organism Organism;
        protected TLevelQueryHandler Sut;
        protected TILevelQueryHandlerMagicStrings LevelQueryHandlerMagicStrings;

        protected abstract Tolerances GetTolerances();
        protected abstract string GetOrganismName();

        [SetUp]
        protected void LevelQueryHandlerTestsSetUp()
        {
            LevelQueryHandlerMagicStrings = Substitute.For<TILevelQueryHandlerMagicStrings>();
            LevelQueryHandlerMagicStrings.OrganismNotDefinedExceptionMessage.Returns(OrganismNotDefinedExceptionMessage);
            LevelQueryHandlerMagicStrings.OrganismTolerancesNotDefinedExceptionMessage.Returns(OrganismTolerancesNotDefinedExceptionMessage);
        }

        [Test]
        public void organism_not_defined_ArgumentNullException_thrown()
        {
            var query = Activator.CreateInstance(typeof(TQuery), null) as TQuery;
            Action act = () => Sut.Handle(query);
            AssertArgumentNullException(act, OrganismNotDefinedExceptionMessage, nameof(query.Organism));
        }


        protected abstract IEnumerable<double> is_suitable_cases();
        [Test]
        public void is_suitable()
        {
            foreach (var isSuitableCase in is_suitable_cases())
            {
                var query = Activator.CreateInstance(typeof(TQuery), isSuitableCase, Organism) as TQuery;
                var result = Sut.Handle(query);
                result.SutablalForOrganism.Should().BeTrue();
            }
            
        }

        protected abstract IEnumerable<double> is_not_suitable_cases();
        [Test]
        public void is_not_suitable()
        {
            foreach (var isNotSuitableCase in is_not_suitable_cases())
            {
                var query = Activator.CreateInstance(typeof(TQuery), isNotSuitableCase, Organism) as TQuery;

                var result = Sut.Handle(query);
                result.SutablalForOrganism.Should().BeFalse();
            }
        }

        protected abstract IEnumerable<double> is_not_ideal_cases();
        [Test]
        public void is_not_ideal()
        {
            foreach (var isNotIdealCase in is_not_ideal_cases())
            {
                var query = Activator.CreateInstance(typeof(TQuery), isNotIdealCase, Organism) as TQuery;

                var result = Sut.Handle(query);
                result.IdealForOrganism.Should().BeFalse();
            }
        }

        protected abstract IEnumerable<double> is_ideal_cases();
        [Test]
        public void is_ideal()
        {
            foreach (var isIdealCase in is_ideal_cases())
            {
                var query = Activator.CreateInstance(typeof(TQuery), isIdealCase, Organism) as TQuery;

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
