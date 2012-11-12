using Lender.Slos.Dao;
using NUnit.Framework;

namespace Tests.Unit.Lender.Slos.Dao
{
    public class ApplicationEntityTests
    {
        [Test]
        public void Id_WhenIdIsSet_ExpectGetReturnsProperId()
        {
            // Arrange
            const int expected = 7;
            
            var classUnderTest =
                new ApplicationEntity
                    {
                        Id = expected,
                    };

            // Act
            var actual = classUnderTest.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
