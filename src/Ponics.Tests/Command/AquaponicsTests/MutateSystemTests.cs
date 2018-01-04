using NSubstitute;
using NUnit.Framework;
using Ponics.Aquaponics;
using Ponics.Kernel.Commands;
using Ponics.Kernel.Queries;

namespace Ponics.Tests.Command.AquaponicsTests
{
    public abstract class MutateSystemTests<TSut>
    {
        protected IDataCommandHandler<UpdateSystem> UpdateSystemDataCommandHandler;
        protected IDataQueryHandler<GetSystem, AquaponicSystem> GetSystemDataCommandHandler;
        protected AquaponicSystem AquaponicSystem;
        protected TSut Sut;

        [SetUp]
        public void SetUp()
        {
            UpdateSystemDataCommandHandler = Substitute.For<IDataCommandHandler<UpdateSystem>>();
            GetSystemDataCommandHandler = Substitute.For<IDataQueryHandler<GetSystem, AquaponicSystem>>();
            AquaponicSystem = new AquaponicSystem();
            GetSystemDataCommandHandler.Handle(Arg.Any<GetSystem>()).Returns(AquaponicSystem);
        }
    }
}
