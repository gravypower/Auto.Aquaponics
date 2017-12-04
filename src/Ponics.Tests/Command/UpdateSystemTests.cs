using NSubstitute;
using NUnit.Framework;
using Ponics.AquaponicSystems;
using Ponics.Kernel.Data;
using System;
using Ponics.Components;

namespace Ponics.Tests.Command
{
    public abstract class UpdateSystemTests<TSut>
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
