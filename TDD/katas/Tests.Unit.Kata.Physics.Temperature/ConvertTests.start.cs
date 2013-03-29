using Kata.Physics.Temperature;
using NUnit.Framework;

namespace Tests.Unit.Kata.Physics.Temperature
{
    public class ConverterTests
    {
        [Test]
        public void CelsiusToFahrenheit_WhenPassed0Celcius_Expect32Fahrenheit()
        {
            // Arrange
            int temperature = 0;

            // Act
            var result = Converter.CelsiusToFahrenheit(temperature);

            // Assert
            Assert.AreEqual(32, result);
        }
    }
}
