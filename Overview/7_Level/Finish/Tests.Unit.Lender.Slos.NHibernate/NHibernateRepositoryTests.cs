using Lender.Slos.Dao;
using Lender.Slos.NHibernate;
using Moq;
using NHibernate;
using NUnit.Framework;

namespace Tests.Unit.Lender.Slos.NHibernate
{
    public class NHibernateRepositoryTests
    {
        [Test]
        public void Retrieve_WhenPassValidId_ExpectIndividualIsValid()
        {
            // Arrange
            const int id = 7;

            var individual = new IndividualEntity {Id = id};

            var stubSession = new Mock<ISession>();
            stubSession.Setup(e => e.Get<IndividualEntity>(id))
                .Returns(individual);

            var classUnderTest = new NHibernateRepository<IndividualEntity>(stubSession.Object);

            // Act
            var actual = classUnderTest.Retrieve(id);

            // Assert
            Assert.IsNotNull(actual);
        }
    }
}
