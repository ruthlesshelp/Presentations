using System;

using Moq;

using NUnit.Framework;

using Lender.Slos.Financial;
using Lender.Slos.Utilities.Configuration;

namespace Tests.Unit.Lender.Slos.Financial
{
    public class ModificationWindowTests
    {
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(12)]
        public void Allowed_WhenCurrentDateIsInsideModificationWindow_ExpectTrue(
            int startMonth)
        {
            // Arrange
            var settings = new Mock<IModificationWindowSettings>();
            settings
                .SetupGet(e => e.StartMonth)
                .Returns(startMonth);
            settings
                .SetupGet(e => e.StartDay)
                .Returns(1);

            var currentTime = new DateTime(
                DateTime.Now.Year,
                startMonth,
                13);

            var classUnderTest = new ModificationWindow(settings.Object);

            // Act
            var result = classUnderTest.Allowed(currentTime);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestCase(1, 1, 2012, 2, 2)]
        // [TestCase(5, 17, 2012, 5, 13)]
        public void Allowed_WhenCurrentDateIsOutsideModificationWindow_ExpectFalse(
            int startMonth,
            int startDay,
            int currentYear,
            int currentMonth,
            int currentDay)
        {
            // Arrange
            var settings = new Mock<IModificationWindowSettings>();
            settings
                .SetupGet(e => e.StartMonth)
                .Returns(startMonth);
            settings
                .SetupGet(e => e.StartDay)
                .Returns(startDay);

            var currentTime = new DateTime(
                currentYear,
                currentMonth,
                currentDay);

            var classUnderTest = new ModificationWindow(settings.Object);

            // Act
            var result = classUnderTest.Allowed(currentTime);

            // Assert
            Assert.AreEqual(false, result);
        }
    }
}
