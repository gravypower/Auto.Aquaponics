
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Ponics.Kernel.Data;
using Ponics.Organisms;

namespace Ponics.Tests.Query
{
    [TestFixture]
    public class GetAllOrganismsQueryHandlerTests
    {
        public GetAllOrganismsQueryHandler Sut;
        private IDataQueryHandler<GetAllOrganisms, IList<Organism>> _getAllOrganismsDataQueryHandler;

        [SetUp]
        public void SetUp()
        {
            _getAllOrganismsDataQueryHandler = Substitute.For<IDataQueryHandler<GetAllOrganisms, IList<Organism>>>();
            Sut = new GetAllOrganismsQueryHandler(_getAllOrganismsDataQueryHandler);
        }

        [Test]
        public void CanGetAddOrganisms()
        {
            //Assign
            var getAllOrganisms = new GetAllOrganisms();

            //Act
            Sut.Handle(getAllOrganisms);

            //Assert
            _getAllOrganismsDataQueryHandler.Received().Handle(getAllOrganisms);
        }
    }
}
