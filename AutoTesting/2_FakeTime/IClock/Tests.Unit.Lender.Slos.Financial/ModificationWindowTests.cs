using System;
using Lender.Slos.Utilities.Clock;
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

            var clock = new Mock<IClock>();
            clock
                .SetupGet(e => e.Now)
                .Returns(currentTime);

            var classUnderTest = 
                new ModificationWindow(
                    clock.Object,
                    settings.Object);

            // Act
            var result = classUnderTest.Allowed();

            // Assert
            Assert.AreEqual(true, result);
        }
        
        [TestCase(5, 17, 2012, 5, 19)]
        public void Allowed_WhenCurrentDateIsInsideModificationWindow_ExpectTrue(
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

            var clock = new Mock<IClock>();
            clock
                .SetupGet(e => e.Now)
                .Returns(currentTime);

            var classUnderTest =
                new ModificationWindow(
                    clock.Object, 
                    settings.Object);

            // Act
            var result = classUnderTest.Allowed();

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestCase(5, 17, 2012, 5, 13)]
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

            var clock = new Mock<IClock>();
            clock
                .SetupGet(e => e.Now)
                .Returns(currentTime);

            var classUnderTest =
                new ModificationWindow(
                    clock.Object,
                    settings.Object);

            // Act
            var result = classUnderTest.Allowed();

            // Assert
            Assert.AreEqual(false, result);
        }
    }
}

