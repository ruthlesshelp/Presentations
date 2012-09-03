using System;

using Lender.Slos.Utilities.Configuration;

namespace Lender.Slos.Financial
{
    public class ModificationWindow
    {
        private readonly IModificationWindowSettings _settings;

        public ModificationWindow(
            IModificationWindowSettings settings)
        {
            _settings = settings;
        }

        // Inject the class dependency on DateTime.Now
        private DateTime? _now;
        public DateTime Now
        {
            get
            {
                return _now ?? DateTime.Now;
            }
            internal set
            {
                _now = value;
            }
        }

        public bool Allowed()
        {
            var now = this.Now;

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
