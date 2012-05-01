using System;
using System.Data.SqlTypes;
using System.Text;
using NUnit.Framework;

namespace Tests.Unit.Lender.Slos.Database.Helpers
{
    internal static class TestDataHelper
    {
        private static readonly Random Randomizer = new Random();

        public const int DefaultMaxStringLength = 50;
        public const string UpperCaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string LowerCaseLetters = "abcdefghijklmnopqrstuvwxyz";

        public const decimal DefaultMinimumMoneyAmount = 1000.00m;
        public const decimal DefaultMaximumMoneyAmount = 1000000.00m;

        public const decimal DefaultMinimumPercentageRate = 1.0000m;
        public const decimal DefaultMaximumPercentageRate = 20.0000m;

        public const int DefaultMinimumCount = 1;
        public const int DefaultMaximumCount = 1000;

        public static string BuildNameString(
            int? length = null)
        {
            var generatedLength = length ?? Randomizer.Next(1, DefaultMaxStringLength);

            Assert.Greater(generatedLength, 0);

            var stringBuilder = new StringBuilder(generatedLength);
            stringBuilder.Append(UpperCaseLetters[Randomizer.Next(0, UpperCaseLetters.Length - 1)]);
            for (var index = 1; index < generatedLength; index++)
            {
                stringBuilder.Append(LowerCaseLetters[Randomizer.Next(0, LowerCaseLetters.Length - 1)]);
            }

            return stringBuilder.ToString();
        }

        public static SqlDateTime BuildSqlDateTime(
            DateTime? minValue = null,
            DateTime? maxValue = null)
        {
            // SqlDateTime must be between 1/1/1753 12:00:00 AM and 12/31/9999 11:59:59 PM
            var minSqlDateTime = new SqlDateTime(minValue ?? SqlDateTime.MinValue.Value);
            var maxSqlDateTime = new SqlDateTime(maxValue ?? SqlDateTime.MaxValue.Value);

            Assert.Greater(maxSqlDateTime, minSqlDateTime, 
                "TestDataHelper error: maxValue must be greater than minValue");

            var range = (maxSqlDateTime.Value - minSqlDateTime.Value).Ticks;
            return new DateTime((long)(minSqlDateTime.Value.Ticks + (Randomizer.NextDouble() * range)));
        }

        public static decimal BuildMoney(
            decimal? minValue = null,
            decimal? maxValue = null)
        {
            // By default money is in the range of $1,000.00 to $1,000,000.00
            var minMoney = minValue ?? DefaultMinimumMoneyAmount;
            var maxMoney = maxValue ?? DefaultMaximumMoneyAmount;

            Assert.Greater(maxMoney, minMoney,
                "TestDataHelper error: maxValue must be greater than minValue");

            var range = maxMoney - minMoney;

            return Math.Round(
                minMoney + 
                (range * (decimal)Randomizer.NextDouble()), 2, MidpointRounding.AwayFromZero);
        }

        public static decimal BuildPercentageRate(
            decimal? minValue = null,
            decimal? maxValue = null)
        {
            // By default percentage rate is in the range of 1.0000% to 20.0000%
            var minRate = minValue ?? DefaultMinimumPercentageRate;
            var maxRate = maxValue ?? DefaultMaximumPercentageRate;

            Assert.Greater(maxRate, minRate,
                "TestDataHelper error: maxValue must be greater than minValue");

            var range = maxRate - minRate;

            return Math.Round(
                minRate + 
                (range * (decimal)Randomizer.NextDouble()), 4, MidpointRounding.AwayFromZero);
        }

        public static int BuildCount(
            int? minValue = null,
            int? maxValue = null)
        {
            // By default total number of payments is in the range of 1 and 1000
            var minRate = minValue ?? DefaultMinimumCount;
            var maxRate = maxValue ?? DefaultMaximumCount;

            Assert.Greater(maxRate, minRate,
                "TestDataHelper error: maxValue must be greater than minValue");

            var range = maxRate - minRate;

            return minRate + Randomizer.Next(0, range);
        }
    }
}
