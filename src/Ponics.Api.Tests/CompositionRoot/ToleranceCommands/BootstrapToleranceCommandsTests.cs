using System;
using System.Linq;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Ponics.Analysis.Levels.Ammonia.Commands;
using Ponics.Analysis.Levels.Iron.Commands;
using Ponics.Analysis.Levels.Nitrate.Commands;
using Ponics.Analysis.Levels.Nitrite.Commands;
using Ponics.Analysis.Levels.Ph.Commands;
using Ponics.Analysis.Levels.Salinity.Commands;
using Ponics.Api.CompositionRoot.ToleranceCommands;
using Ponics.Commands;
using Ponics.Kernel.Commands;
using SimpleInjector;

namespace Ponics.Api.Tests.CompositionRoot.ToleranceCommands
{
    [TestFixture]
    public class BootstrapToleranceCommandsTests
    {
        public BootstrapToleranceCommands Sut;

        [SetUp]
        public void SetUp()
        {
            Sut = Substitute.For<BootstrapToleranceCommands>();
            Sut.CommandType.Returns(typeof(ToleranceCommand<>));
            Sut.ToleranceCommandHandlerType.Returns(typeof(ToleranceCommandHandler<>));
        }

        [Test]
        public void CanGetToleranceCommandTypes()
        {
            //Act
            var types = Sut.GetToleranceCommandTypes();

            //Assert
            types.Should().Contain(typeof(AddStubToleranceCommand));
        }

        [Test]
        public void CanBootstrapAddToleranceCommandHandlers()
        {
            //Assign
            var container = new Container();

            //Act
            Sut.Bootstrap(container);

            //Assert
            var currentRegistrations = container.GetInstance<ICommandHandler<AddStubToleranceCommand>>();
            currentRegistrations
                .GetType()
                .IsAssignableFrom(typeof(ToleranceCommandHandler<StubTolerance>))
                .Should()
                .BeTrue();
        }

        [Test]
        public void IntegrationAddTolerance()
        {
            //Assign
            var container = new Container();
            var add = new BootstrapAddTolerance();

            //Act
            add.Bootstrap(container);

            //Assert
            var currentRegistrations = container.GetCurrentRegistrations();
            var serviceTypes = currentRegistrations.Select(st => st.ServiceType).ToList();


            serviceTypes.Should().Contain(typeof(ICommandHandler<AddIronTolerance>));
            serviceTypes.Should().Contain(typeof(ICommandHandler<AddAmmoniaTolerance>));
            serviceTypes.Should().Contain(typeof(ICommandHandler<AddNitrateTolerance>));
            serviceTypes.Should().Contain(typeof(ICommandHandler<AddNitriteTolerance>));
            serviceTypes.Should().Contain(typeof(ICommandHandler<AddSalinityTolerance>));
            serviceTypes.Should().Contain(typeof(ICommandHandler<AddPhTolerance>));
        }

        [Test]
        public void IntegrationDeleteTolerance()
        {
            //Assign
            var container = new Container();
            var add = new BootstrapDeleteTolerance();

            //Act
            add.Bootstrap(container);

            //Assert
            var currentRegistrations = container.GetCurrentRegistrations();
            var serviceTypes = currentRegistrations.Select(st => st.ServiceType).ToList();


            serviceTypes.Should().Contain(typeof(ICommandHandler<DeleteIronTolerance>));
            serviceTypes.Should().Contain(typeof(ICommandHandler<DeleteAmmoniaTolerance>));
            serviceTypes.Should().Contain(typeof(ICommandHandler<DeleteNitrateTolerance>));
            serviceTypes.Should().Contain(typeof(ICommandHandler<DeleteNitriteTolerance>));
            serviceTypes.Should().Contain(typeof(ICommandHandler<DeleteSalinityTolerance>));
            serviceTypes.Should().Contain(typeof(ICommandHandler<DeletePhTolerance>));
        }

        [Test]
        public void IntegrationUpdateTolerance()
        {
            //Assign
            var container = new Container();
            var add = new BootstrapUpdateTolerance();

            //Act
            add.Bootstrap(container);

            //Assert
            var currentRegistrations = container.GetCurrentRegistrations();
            var serviceTypes = currentRegistrations.Select(st => st.ServiceType).ToList();

            serviceTypes.Should().Contain(typeof(ICommandHandler<UpdateIronTolerance>));
            serviceTypes.Should().Contain(typeof(ICommandHandler<UpdateAmmoniaTolerance>));
            serviceTypes.Should().Contain(typeof(ICommandHandler<UpdateNitrateTolerance>));
            serviceTypes.Should().Contain(typeof(ICommandHandler<UpdateNitriteTolerance>));
            serviceTypes.Should().Contain(typeof(ICommandHandler<UpdateSalinityTolerance>));
            serviceTypes.Should().Contain(typeof(ICommandHandler<UpdatePhTolerance>));
        }
    }
}
