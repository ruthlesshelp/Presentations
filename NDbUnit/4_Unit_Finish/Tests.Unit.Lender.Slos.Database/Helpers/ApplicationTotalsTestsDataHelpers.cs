using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using Tests.Unit.Lender.Slos.Database.Bases;
using Tests.Unit.Lender.Slos.Database.StoredProcs;

namespace Tests.Unit.Lender.Slos.Database.Helpers
{
    [ExcludeFromCodeCoverage]
    public class ApplicationTotalsTestsDataHelpers :
        DataHelperBase<ApplicationTotalsTestsContext>
    {
#if !SUPPRESS_MANUAL_TESTS
        [Test]
        [Ignore("Helper to extract data from the specified SQL Server database")]
#endif
        public void HelperMethod_ExportTestDataFromDatabase()
        {
            ExportTestDataFromDatabase();
        }
    }
}