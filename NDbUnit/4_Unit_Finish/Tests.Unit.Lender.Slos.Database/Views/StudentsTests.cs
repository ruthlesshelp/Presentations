using NUnit.Framework;
using Tests.Unit.Lender.Slos.Database.Bases;
using Tests.Unit.Lender.Slos.Database.Helpers;

namespace Tests.Unit.Lender.Slos.Database.Views
{
    public class StudentsTests
        : SurfaceTestingBase<StudentsTestsContext>
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

        [TestCase("Students_Scenario01.xml", 0)]
        [TestCase("Students_Scenario02.xml", 2)]
        [TestCase("Students_Scenario03.xml", 4)]
        public void Students_WithValidParameters_ExpectProperCount(
            string xmlDataFilename,
            int expectedCount)
        {
            // Arrange
            TestFixtureContext.SetupTestDatabase(xmlDataFilename);

            var sqlHelper = new DalHelper(TestFixtureContext.ConnectionString);

            var text = TestFixtureContext.CreateQuery("vw_Students");

            // Act
            var actual = sqlHelper.ExecuteSelectCommand(
                text);

            // Assert
            Assert.NotNull(actual);
            var table = actual.Tables[0];
            Assert.NotNull(table);
            Assert.AreEqual(expectedCount, table.Rows.Count);
        }
    }
}
