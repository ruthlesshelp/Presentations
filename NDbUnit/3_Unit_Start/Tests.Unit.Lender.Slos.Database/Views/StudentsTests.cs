namespace Tests.Unit.Lender.Slos.Database.Views
{
    using System.Data;
    using System.Data.SqlClient;
    using NDbUnit.Core;
    using NDbUnit.Core.SqlClient;
    using NUnit.Framework;

    public class StudentsTests
    {
        private const string ConnectionString =
            @"Data Source=(local)\SQLExpress;Initial Catalog=Lender.Slos;Integrated Security=True";

        private INDbUnitTest _database;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            _database = new SqlDbUnitTest(ConnectionString);

            _database.ReadXmlSchema(@"..\..\Data\Lender.Slos.DataSet.xsd");
            _database.ReadXml(@"..\..\Data\Students_Scenario01.xml");
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
        public void Students_WithScenarioDataInDatabase_ExpectCountIs1()
        {
            // Arrange

            // Act
            DataSet actual;

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                actual = new DataSet();

                var command = sqlConnection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM vw_Students";

                sqlConnection.Open();

                var adapter = new SqlDataAdapter(command);
                adapter.Fill(actual);

                command.Parameters.Clear();
            }

            // Assert
            Assert.NotNull(actual);
            var table = actual.Tables[0];
            Assert.NotNull(table);
            Assert.AreEqual(1, table.Rows.Count);
        }
    }
}
