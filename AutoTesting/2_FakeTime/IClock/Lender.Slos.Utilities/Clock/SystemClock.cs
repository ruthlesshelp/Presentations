using System;

namespace Lender.Slos.Utilities.Clock
{
    public class SystemClock : IClock
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }
    }
}