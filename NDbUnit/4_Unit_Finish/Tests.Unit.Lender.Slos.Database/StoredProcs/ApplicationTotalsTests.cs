using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using NUnit.Framework;
using Tests.Unit.Lender.Slos.Database.Bases;
using Tests.Unit.Lender.Slos.Database.Helpers;

namespace Tests.Unit.Lender.Slos.Database.StoredProcs
{
    public class ApplicationTotalsTests
        : SurfaceTestingBase<ApplicationTotalsTestsContext>
    {
        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            this.SetUpTestFixture();
        }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            Dispose();
        }

        [TestCase("ApplicationTotals_Scenario01.xml", 1003, null)]
        [TestCase("ApplicationTotals_Scenario02.xml", 1003, "107988.00")]
        [TestCase("ApplicationTotals_Scenario03.xml", 1003, "411025.00")]
        public void ApplicationTotals_WithScenarioDataInDatabase_ExpectProperTotal(
            string xmlDataFilename,
            int studentId,
            string expectedTotalAsString)
        {
            // Arrange
            var expectedTotal = expectedTotalAsString == null 
                ? (decimal?)null 
                : decimal.Parse(expectedTotalAsString);

            TestFixtureContext.SetupTestDatabase(xmlDataFilename);
            var sqlHelper = new DalHelper(TestFixtureContext.ConnectionString);

            var parameters =
                new List<SqlParameter>
                    {
                        new SqlParameter("StudentId", studentId),
                    };

            // Act
            var actual = sqlHelper.ExecuteStoredProcedure(
                "rpt_ApplicationTotals",
                parameters);

            // Assert
            Assert.IsNotNull(actual);
            Assert.True(actual.Tables[0].Columns.Contains("Total"));
            var actualTotal = actual.Tables[0].Rows[0].Field<decimal?>("Total");

            Assert.AreEqual(expectedTotal, actualTotal);
        }
    }
}
