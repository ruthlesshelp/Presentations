using Lender.Slos.Financial;
using NUnit.Framework;

namespace Tests.Unit.Lender.Slos.Financial
{
    public class CalculatorTests
    {
        [Test]
        public void ComputeRatePerPeriod_WhenAnnualPercentageRateIs19_9_ExpectRatePerPeriodIs0_016583()
        {
            // Arrange
            const decimal annualPercentageRate = 19.9m;

            // Act
            var actual = Calculator.ComputeRatePerPeriod(annualPercentageRate);

            // Assert
            Assert.AreEqual(0.016583m, actual);
        }
    }
}
