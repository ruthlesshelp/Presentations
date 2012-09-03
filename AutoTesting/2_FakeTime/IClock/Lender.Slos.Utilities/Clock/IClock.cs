using System;

namespace Lender.Slos.Utilities.Clock
{
    public interface IClock
    {
        DateTime Now { get; }
    }
}