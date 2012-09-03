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
            var now = DateTime.Now;

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
