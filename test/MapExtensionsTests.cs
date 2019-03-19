using System;
using Xunit;
using FS4CSharp;

namespace FS4CSharp.Tests
{
    public class MapExtensionsTests
    {
        [Fact]
        public void MapUsage1()
        {
            Func<double, double> CelsiusToFahrenheit = c =>
                c * (9/5D) + 32;

            Func<double, double> FahrenheitToCelsius = f =>
                (f - 32) / (9/5D);

            const double zeroCelsius = 0;
            var result = zeroCelsius
                .Map(CelsiusToFahrenheit)
                .Map(FahrenheitToCelsius);
            Assert.Equal(zeroCelsius, result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void MapsIntegersToStrings(int input)
        {
            var result = input.Map(n => n.ToString());
            Assert.Equal(input.ToString(), result);
        }

        [Theory]
        [InlineData("-1")]
        [InlineData("0")]
        [InlineData("1")]
        public void MapsStringsToIntegers(string input)
        {
            var result = input.Map(s => int.Parse(s));
            Assert.Equal(int.Parse(input), result);
        }

        [Fact]
        public void MapsToSelf()
        {
            var input = "abc";
            var number = 0;

            var output = input.Map(() => number++);

            Assert.Same(input, output);
            Assert.Equal(1, number);
        }

        public void MapFinalSample()
        {
            var input = "123";

            input.MapFinal(s => int.Parse(s));
        }
    }
}
