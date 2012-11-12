using Lender.Slos.Dal;
using Lender.Slos.Dao;
using Moq;
using NHibernate;
using NUnit.Framework;

namespace Tests.Unit.Lender.Slos.Dal
{
    public class ApplicationDalTests
    {
        [Test]
        public void Retrieve_WhenValidIdIsPassed_ExpectValidResult()
        {
            // Arrange
            const int id = 6211;

            var applicationEntity = new ApplicationEntity();

            var stubSession = new Mock<ISession>(MockBehavior.Loose);
            stubSession.Setup(e => e.Get<ApplicationEntity>(id))
                .Returns(applicationEntity);

            var classUnderTest = new ApplicationDal(stubSession.Object);

            // Act
            var result = classUnderTest.Retrieve(id);

            // Assert
            Assert.NotNull(result);
        }
    }
}
