using Kata.Physics.Temperature;
using NUnit.Framework;

namespace Tests.Unit.Kata.Physics.Temperature
{
    public class ConverterTests
    {
        [TestCase(0, 32)]
        [TestCase(100, 212)]
        [TestCase(-40, -40)]
        [TestCase(5, 41)]
        [TestCase(18.71, 65.68)]
        public void CelsiusToFahrenheit_WhenPassedTemperatureInCelcius_ExpectProperTemperatureInFahrenheit(
            decimal celciusTemperature,
            decimal expectedTemperature)
        {
            // Arrange

            // Act
            var result = Converter.CelsiusToFahrenheit(celciusTemperature);

            // Assert
            Assert.AreEqual(expectedTemperature, result);
        }

        [TestCase(32, 0)]
        [TestCase(212, 100)]
        [TestCase(-40, -40)]
        [TestCase(239, 115)]
        [TestCase(163.25, 72.92)]
        public void FahrenheitToCelsius_WhenPassedTemperatureInFahrenheit_ExpectProperTemperatureInCelcius(
            decimal fahrenheitTemperature,
            decimal expectedTemperature)
        {
            // Arrange

            // Act
            var result = Converter.FahrenheitToCelsius(fahrenheitTemperature);

            // Assert
            Assert.AreEqual(expectedTemperature, result);
        }
    }
}
