using Lender.Slos.Utilities.Configuration;
using NUnit.Framework;

namespace Tests.Unit.Lender.Slos.Financial
{
    public class ProductionSettingsTests
    {
        [Test]
        public void GetStartMonth_Always_Expect12()
        {
            // Arrange
            var classUnderTest = new ProductionSettings();

            // Act
            var result = classUnderTest.StartMonth;

            // Assert
            Assert.AreEqual(12, result);
        }

        [Test]
        public void GetStartDay_Always_Expect1()
        {
            // Arrange
            var classUnderTest = new ProductionSettings();

            // Act
            var result = classUnderTest.StartDay;

            // Assert
            Assert.AreEqual(1, result);
        }
    }
}
