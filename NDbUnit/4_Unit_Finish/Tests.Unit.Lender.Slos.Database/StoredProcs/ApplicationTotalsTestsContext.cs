using Tests.Unit.Lender.Slos.Database.Bases;
using Tests.Unit.Lender.Slos.Database.Helpers;

namespace Tests.Unit.Lender.Slos.Database.StoredProcs
{
    public class ApplicationTotalsTestsContext
        : TestContextBase
    {
        public ApplicationTotalsTestsContext()
            : base(typeof(DalHelper))
        {
        }
    }
}