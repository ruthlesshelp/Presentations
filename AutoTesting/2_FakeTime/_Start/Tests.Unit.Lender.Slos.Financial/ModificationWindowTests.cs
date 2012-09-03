using System;

using Moq;

using NUnit.Framework;

using Lender.Slos.Financial;
using Lender.Slos.Utilities.Configuration;

namespace Tests.Unit.Lender.Slos.Financial
{
    public class ModificationWindowTests
    {
        [Test]
        public void Allowed_WhenCurrentDateIsInsideModificationWindow_ExpectTrue()
        {
            // Arrange
            var startMonth = DateTime.Now.Month;

            var settings = new Mock<IModificationWindowSettings>();
            settings
                .SetupGet(e => e.StartMonth)
                .Returns(startMonth);
            settings
                .SetupGet(e => e.StartDay)
                .Returns(1);

            var classUnderTest = new ModificationWindow(settings.Object);

            // Act
            var result = classUnderTest.Allowed();

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void Allowed_WhenCurrentDateIsOutsideModificationWindow_ExpectFalse()
        {
            // Arrange
            var startMonth = DateTime.Now.Month;

            var settings = new Mock<IModificationWindowSettings>();
            settings
                .SetupGet(e => e.StartMonth)
                .Returns(startMonth + 1);
            settings
                .SetupGet(e => e.StartDay)
                .Returns(1);

            var classUnderTest = new ModificationWindow(settings.Object);

            // Act
            var result = classUnderTest.Allowed();

            // Assert
            Assert.AreEqual(false, result);
        }
    }
}
