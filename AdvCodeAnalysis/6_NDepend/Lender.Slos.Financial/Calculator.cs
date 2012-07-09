namespace Lender.Slos.Financial
{
    using System;
    using System.Globalization;

    public static class Calculator
    {
        public const int MaxTermInMonths = 360;

        public const decimal MinPrincipalAmount = 1000m;
        public const decimal MaxPrincipalAmount = 1000000m;

        public const decimal PeriodsPerYear = 12m;

        public static decimal ComputeRatePerPeriod(
            decimal annualPercentageRate)
        {
            if (annualPercentageRate < 0.01m ||
                annualPercentageRate >= 20.0m)
            {
                throw new InvalidOperationException(string.Format(
                    "AnnualPercentageRate {0}% is not valid",
                    annualPercentageRate));
            }

            var ratePerMonth = (annualPercentageRate / 100m) / PeriodsPerYear;

            return Math.Round(ratePerMonth, 6, MidpointRounding.AwayFromZero);
        }

        public static decimal ComputePaymentPerPeriod(
            decimal principalAmount,
            decimal ratePerPeriod,
            int termInPeriods)
        {
            // FxCop: rule violation
            // CA1809: Avoid excessive locals.
            #region CA1809
            //int excesiveLocal001;
            //int excesiveLocal002;
            //int excesiveLocal003;
            //int excesiveLocal004;
            //int excesiveLocal005;
            //int excesiveLocal006;
            //int excesiveLocal007;
            //int excesiveLocal008;
            //int excesiveLocal009;
            //int excesiveLocal010;
            //int excesiveLocal011;
            //int excesiveLocal012;
            //int excesiveLocal013;
            //int excesiveLocal014;
            //int excesiveLocal015;
            //int excesiveLocal016;
            //int excesiveLocal017;
            //int excesiveLocal018;
            //int excesiveLocal019;
            //int excesiveLocal020;
            //int excesiveLocal021;
            //int excesiveLocal022;
            //int excesiveLocal023;
            //int excesiveLocal024;
            //int excesiveLocal025;
            //int excesiveLocal026;
            //int excesiveLocal027;
            //int excesiveLocal028;
            //int excesiveLocal029;
            //int excesiveLocal030;
            //int excesiveLocal031;
            //int excesiveLocal032;
            //int excesiveLocal033;
            //int excesiveLocal034;
            //int excesiveLocal035;
            //int excesiveLocal036;
            //int excesiveLocal037;
            //int excesiveLocal038;
            //int excesiveLocal039;
            //int excesiveLocal040;
            //int excesiveLocal041;
            //int excesiveLocal042;
            //int excesiveLocal043;
            //int excesiveLocal044;
            //int excesiveLocal045;
            //int excesiveLocal046;
            //int excesiveLocal047;
            //int excesiveLocal048;
            //int excesiveLocal049;
            //int excesiveLocal050;
            //int excesiveLocal051;
            //int excesiveLocal052;
            //int excesiveLocal053;
            //int excesiveLocal054;
            //int excesiveLocal055;
            //int excesiveLocal056;
            //int excesiveLocal057;
            //int excesiveLocal058;
            //int excesiveLocal059;
            //int excesiveLocal060;
            //int excesiveLocal061;
            //int excesiveLocal062;
            //int excesiveLocal063;
            //int excesiveLocal064;
            //int excesiveLocal065;
            //int excesiveLocal066;
            //int excesiveLocal067;
            //int excesiveLocal068;
            //int excesiveLocal069;
            //int excesiveLocal070;
            //int excesiveLocal071;
            //int excesiveLocal072;
            //int excesiveLocal073;
            //int excesiveLocal074;
            //int excesiveLocal075;
            //int excesiveLocal076;
            //int excesiveLocal077;
            //int excesiveLocal078;
            //int excesiveLocal079;
            //int excesiveLocal080;
            //int excesiveLocal081;
            //int excesiveLocal082;
            //int excesiveLocal083;
            //int excesiveLocal084;
            //int excesiveLocal085;
            //int excesiveLocal086;
            //int excesiveLocal087;
            //int excesiveLocal088;
            //int excesiveLocal089;
            //int excesiveLocal090;
            //int excesiveLocal091;
            //int excesiveLocal092;
            //int excesiveLocal093;
            //int excesiveLocal094;
            //int excesiveLocal095;
            //int excesiveLocal096;
            //int excesiveLocal097;
            //int excesiveLocal098;
            //int excesiveLocal099;
            //int excesiveLocal100;
            #endregion

            if (termInPeriods <= 0 || termInPeriods > MaxTermInMonths)
            {
                throw new ArgumentOutOfRangeException("termInPeriods");
            }

            if (principalAmount < MinPrincipalAmount || 
                principalAmount >= MaxPrincipalAmount)
            {
                throw new InvalidOperationException(string.Format(
                    "Principal {0} is not valid", 
                    principalAmount.ToString("C", new CultureInfo("EN-us"))));
            }

            var exponentBase = Convert.ToDouble(decimal.One + ratePerPeriod);
            var exponent = Convert.ToDecimal(Math.Pow(exponentBase, -1 * termInPeriods));

            var payment = (ratePerPeriod * principalAmount) / (1m - exponent);
            payment = Math.Round(payment, 2, MidpointRounding.AwayFromZero);

            return payment;
        }
    }
}
