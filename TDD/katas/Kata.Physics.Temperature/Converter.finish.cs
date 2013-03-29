using System;

namespace Kata.Physics.Temperature
{
    public static class Converter
    {
        public static decimal CelsiusToFahrenheit(decimal celsius)
        {
             // °F = °C  x  9/5 + 32
            var fahrenheit = (celsius*9m)/5m + 32m;

            return decimal.Round(fahrenheit, 2, MidpointRounding.AwayFromZero);
        }

        public static decimal FahrenheitToCelsius(decimal fahrenheit)
        {
            // °C = (°F  -  32)  x  5/9
            var celsius = ((fahrenheit - 32m)*5m)/9m;

            return decimal.Round(celsius, 2, MidpointRounding.AwayFromZero);
        }
    }
}
