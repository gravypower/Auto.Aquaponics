using NSubstitute;
using NUnit.Framework;
using Ponics.Aquaponics;
using Ponics.Aquaponics.Commands;
using Ponics.Aquaponics.Queries;
using Ponics.Kernel.Commands;
using Ponics.Kernel.Queries;

namespace Ponics.Tests.Command.AquaponicsTests
{
    public abstract class MutateSystemTests<TSut>
    {
        protected IDataCommandHandler<UpdateAquaponicSystem> UpdateSystemDataCommandHandler;
        protected IDataQueryHandler<GetAquaponicSystem, AquaponicSystem> GetSystemDataCommandHandler;
        protected AquaponicSystem AquaponicSystem;
        protected TSut Sut;

        [SetUp]
        public void SetUp()
        {
            UpdateSystemDataCommandHandler = Substitute.For<IDataCommandHandler<UpdateAquaponicSystem>>();
            GetSystemDataCommandHandler = Substitute.For<IDataQueryHandler<GetAquaponicSystem, AquaponicSystem>>();
            AquaponicSystem = new AquaponicSystem();
            GetSystemDataCommandHandler.Handle(Arg.Any<GetAquaponicSystem>()).Returns(AquaponicSystem);
        }
    }
}
