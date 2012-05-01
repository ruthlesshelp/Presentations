namespace Tests.Unit.Lender.Slos.Database.StoredProcs
{
    using System.Data;
    using System.Data.SqlClient;
    using NDbUnit.Core;
    using NDbUnit.Core.SqlClient;
    using NUnit.Framework;

    public class ApplicationTotalsTests
    {
        private const string ConnectionString =
            @"Data Source=(local)\SQLExpress;Initial Catalog=Lender.Slos;Integrated Security=True";

        private INDbUnitTest _database;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            _database = new SqlDbUnitTest(ConnectionString);

            _database.ReadXmlSchema(@"..\..\Data\Lender.Slos.DataSet.xsd");
            _database.ReadXml(@"..\..\Data\ApplicationTotals_Scenario01.xml");
        }

        [TestFixtureTearDown]
        public void FixtureTeardown()
        {
            _database.PerformDbOperation(DbOperationFlag.DeleteAll);
        }

        [SetUp]
        public void TestSetup()
        {
            _database.Scripts.ClearAll();
            _database.Scripts.AddSingle(@"..\..\Scripts\database.initialization.sql");
            _database.ExecuteScripts();

            _database.PerformDbOperation(DbOperationFlag.CleanInsertIdentity);
        }

        [Test]
        public void ApplicationTotals_WithScenarioDataInDatabase_ExpectTotal303037()
        {
            // Arrange
            const decimal expectedTotal = 303037.00m;

            // Act
            DataSet actual;

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                actual = new DataSet();

                var command = sqlConnection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "rpt_ApplicationTotals";
                command.Parameters.Add(new SqlParameter("StudentId", 3));

                sqlConnection.Open();

                var adapter = new SqlDataAdapter(command);
                adapter.Fill(actual);

                command.Parameters.Clear();
            }

            // Assert
            Assert.IsNotNull(actual);
            Assert.True(actual.Tables[0].Columns.Contains("Total"));
            var actualTotal = actual.Tables[0].Rows[0].Field<decimal?>("Total");

            Assert.AreEqual(expectedTotal, actualTotal);
        }
    }
}
