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

        public bool Allowed()
        {
            // Start date's month & day come from settings
            var startDate = new DateTime(
                DateTime.Now.Year,
                _settings.StartMonth,
                _settings.StartDay);

            // End date is 1 month after the start date
            var endDate = startDate.AddMonths(1);

            if (DateTime.Now >= startDate &&
                DateTime.Now < endDate)
            {
                return true;
            }

            return false;
        }
    }
}
