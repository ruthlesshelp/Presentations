using System;
using NUnit.Framework;
using TypeMock.ArrangeActAssert;

namespace Tests.Unit.Lender.Slos.Financial
{
    public class DateTimeTests
    {
        [TestCase(2000, 1, 1, Description = "Y2K")]
        [Isolated]
        public void Now_WithProvidedYear_ExpectProperDate(
            int year,
            int month,
            int day)
        {
            // Arrange
            var currentDate = new DateTime(year, month, day);

            Isolate
                .WhenCalled(() => DateTime.Now)
                .WillReturn(currentDate);

            // Act
            var result = DateTime.Now;

            // Assert
            Assert.AreEqual(year, result.Year);
        }
    }
}