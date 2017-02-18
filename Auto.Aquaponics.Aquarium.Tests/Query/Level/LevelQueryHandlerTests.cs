using System;
using Auto.Aquaponics.Aquarium.Query.Level;
using Auto.Aquaponics.Organism;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Auto.Aquaponics.Aquarium.Tests.Query.Level
{
    public abstract class LevelQueryHandlerTests
        <
        TLevelQueryHandler,
        TILevelQueryHandlerMagicStrings,
        TQuery, 
        TResult
        >
        where TQuery : LevelQuery, new() where TResult : LevelAnalysis, new() where TILevelQueryHandlerMagicStrings : class, ILevelQueryHandlerMagicStrings
        where TLevelQueryHandler : LevelQueryHandler<TQuery, TResult>
    {

        protected const string OrganismNotDefinedExceptionMessage = "Organism not defined";
        protected const string OrganismTolerancesNotDefinedExceptionMessage = "Organism tolerances not defined";

        protected Organism.Organism Organism;
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

        protected static void AssertArgumentNullException(Action act, string message, string paramName)
        {
            act.ShouldThrow<ArgumentNullException>()
                .WithMessage($"{message}\r\nParameter name: {paramName}");
        }
    }
}
