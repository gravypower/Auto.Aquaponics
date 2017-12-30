﻿using System;
using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Ponics.Aquaponics;
using Ponics.Components;
using Ponics.HardCodedData.Organisms;
using Ponics.Kernel.Data;
using Ponics.Organisms;
using Ponics.Organisms.Handlers;

namespace Ponics.Tests.Query.AquaponicSystems
{
    [TestFixture]
    public class GetSystemOrganismsTests
    {
        private IDataQueryHandler<GetSystem, AquaponicSystem> _getSystemDataQueryHandler;
        private IDataQueryHandler<GetOrganisms, List<Organism>> _getAllOrganismsDataQueryHandler;
        public GetSystemOrganismsQueryHandler Sut;
        private AquaponicSystem _aquaponicSystem;

        [SetUp]
        public void SetUp()
        {
            _getSystemDataQueryHandler = Substitute.For<IDataQueryHandler<GetSystem, AquaponicSystem>>();
            _getAllOrganismsDataQueryHandler = Substitute.For<IDataQueryHandler<GetOrganisms, List<Organism>>>();

            _aquaponicSystem = new AquaponicSystem();
            _getSystemDataQueryHandler.Handle(Arg.Any<GetSystem>()).Returns(_aquaponicSystem);

            Sut = new GetSystemOrganismsQueryHandler(_getSystemDataQueryHandler, _getAllOrganismsDataQueryHandler);
        }

        [Test]
        public void CanGetSystem()
        {
            //Assign
            var query = new GetSystemOrganisms
            {
                Id = Guid.NewGuid()
            };

            //Act
            Sut.Handle(query);

            //Assert
            _getSystemDataQueryHandler.Received().Handle(Arg.Is<GetSystem>(q => q.Id == query.Id));
        }

        [Test]
        public void CanGetOrganismsFromSystemWithOneComponent()
        {
            //Arrange
            var query = new GetSystemOrganisms();

            var component = new Component();
            var silverPerch = new SilverPerch();
            component.Organisms.Add(silverPerch.Id);
            _aquaponicSystem.Components.Add(component);
            _getAllOrganismsDataQueryHandler.Handle(Arg.Any<GetOrganisms>()).Returns(new List<Organism>
            {
                silverPerch
            });

            //Act
            var result = Sut.Handle(query);

            //Assert
            result.Should().Contain(silverPerch);
        }

        [Test]
        public void CanGetOrganismsFromSystemWithTwoComponent()
        {
            //Arrange
            var query = new GetSystemOrganisms();

            var component = new Component();
            var silverPerch = new SilverPerch();
            component.Organisms.Add(silverPerch.Id);
            _aquaponicSystem.Components.Add(component);

            var component2 = new Component();
            var goldFish = new GoldFish();
            component2.Organisms.Add(goldFish.Id);
            _aquaponicSystem.Components.Add(component2);


            _getAllOrganismsDataQueryHandler.Handle(Arg.Any<GetOrganisms>()).Returns(new List<Organism>
            {
                silverPerch,
                goldFish
            });

            //Act
            var result = Sut.Handle(query);

            //Assert
            result.Should().Contain(silverPerch);
            result.Should().Contain(goldFish);
        }

        [Test]
        public void OrganismOnlyReturnedOnce()
        {
            //Arrange
            var query = new GetSystemOrganisms();

            var component = new Component();
            var silverPerch = new SilverPerch();
            component.Organisms.Add(silverPerch.Id);
            _aquaponicSystem.Components.Add(component);

            var component2 = new Component();
            component2.Organisms.Add(silverPerch.Id);
            _aquaponicSystem.Components.Add(component2);


            _getAllOrganismsDataQueryHandler.Handle(Arg.Any<GetOrganisms>()).Returns(new List<Organism>
            {
                silverPerch,
            });

            //Act
            var result = Sut.Handle(query);

            //Assert
            result.Should().Contain(silverPerch);
            result.Count.Should().Be(1);
        }
    }
}
