using Lender.Slos.Dal;
using Lender.Slos.Dao;
using Moq;
using NUnit.Framework;

namespace Tests.Unit.Lender.Slos.Dal
{
    public class ApplicationDalTests
    {
        [Test]
        public void Create_WhenPassedValidApplication_ExpectProperId()
        {
            // Arrange
            const int expectedId = 7;

            var entity = new ApplicationEntity();

            var stubRepository = new Mock<IRepository<ApplicationEntity>>();
            stubRepository.Setup(e => e.Create(entity))
                .Returns(expectedId);

            var classUnderTest = new ApplicationDal(stubRepository.Object);

            // Act
            var actual = classUnderTest.Create(entity);

            // Assert
            Assert.AreEqual(expectedId, actual);
        }
    }
}
