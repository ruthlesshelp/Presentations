using System;
using Lender.Slos.Utilities.Clock;
using Lender.Slos.Utilities.Configuration;

namespace Lender.Slos.Financial
{
    public class ModificationWindow
    {
        private readonly IClock _clock;
        private readonly IModificationWindowSettings _settings;

        public ModificationWindow(
            IClock clock,
            IModificationWindowSettings settings)
        {
            _clock = clock;
            _settings = settings;
        }

        public bool Allowed()
        {
            var now = _clock.Now;

            // Start date's month & day come from settings
            var startDate = new DateTime(
                now.Year,
                _settings.StartMonth,
                _settings.StartDay);

            // End date is 1 month after the start date
            var endDate = startDate.AddMonths(1);

            if (now >= startDate &&
                now < endDate)
            {
                return true;
            }

            return false;
        }
    }
}
