using System;
using Lender.Slos.Dal;
using Lender.Slos.Dal.Entities;

namespace Tests.Unit.Lender.Slos.Dal
{
    using NDbUnit.Core;
    using NDbUnit.Core.SqlClient;

    using NUnit.Framework;

    public class IndividualDalTests
    {
        private const string ConnectionString =
            @"Data Source=(local)\SQLExpress;Initial Catalog=Lender.Slos;Integrated Security=True";

        private INDbUnitTest _database;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            _database = new SqlDbUnitTest(ConnectionString);

            _database.ReadXmlSchema(@"..\..\Data\Lender.Slos.DataSet.xsd");
            _database.ReadXml(@"..\..\Data\IndividualDalTests_Scenario01.xml");
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

        [TestCase(1, "Roosevelt")]
        [TestCase(3, "Smith")]
        [TestCase(5, "Truman")]
        public void Retrieve_WithScenarioDataInDatabase_ExpectProperLastName(
            int id,
            string expectedLastName)
        {
            // Arrange
            var classUnderTest = new IndividualDal(ConnectionString);

            // Act
            var actual = classUnderTest.Retrieve(id);

            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual(expectedLastName, actual.LastName);
        }

        [TestCase(7)]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-11)]
        public void Retrieve_WithScenarioDataInDatabase_ExpectEnityIsNull(
            int id)
        {
            // Arrange
            var classUnderTest = new IndividualDal(ConnectionString);

            // Act
            var actual = classUnderTest.Retrieve(id);

            // Assert
            Assert.Null(actual);
        }

        [TestCase(6)]
        public void Create_WithScenarioDataInDatabase_ExpectProperNextIdIsGenerated(
            int expectedId)
        {
            // Arrange
            var classUnderTest = new IndividualDal(ConnectionString);

            var entity = 
                new IndividualEntity
                             {
                                 LastName = "Jones",
                                 FirstName = "Wilma",
                                 MiddleName = "Vanessa",
                                 DateOfBirth = new DateTime(1993, 11, 17),
                             };

            // Act
            var actual = classUnderTest.Create(entity);

            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual(expectedId, actual);
        }

        [TestCase(3)]
        public void Delete_WithScenarioDataInDatabase_ExpectEntityIsRemoved(
            int id)
        {
            // Arrange
            var classUnderTest = new IndividualDal(ConnectionString);

            var entity = classUnderTest.Retrieve(id);
            Assert.NotNull(entity);

            // Act
            classUnderTest.Delete(entity);

            // Assert
            var result = classUnderTest.Retrieve(id);
            Assert.IsNull(result);
        }

        [TestCase(6, ExpectedException = typeof(InvalidOperationException))]
        public void Delete_WithScenarioDataInDatabase_ExpectInvalidOperationException(
            int id)
        {
            // Arrange
            var classUnderTest = new IndividualDal(ConnectionString);

            var entity =
                new IndividualEntity
                {
                    Id = id,
                };

            // Act
            classUnderTest.Delete(entity);

            // Assert
            Assert.Fail("Expected an exception");
        }

        [TestCase(3, "dd0831f2-1e5e")]
        public void Update_WithScenarioDataInDatabase_ExpectLastNameIsChanged(
            int id,
            string expectedLastname)
        {
            // Arrange
            var classUnderTest = new IndividualDal(ConnectionString);

            var entity = classUnderTest.Retrieve(id);
            Assert.NotNull(entity);

            entity.LastName = expectedLastname;

            // Act
            classUnderTest.Update(entity);

            // Assert
            var result = classUnderTest.Retrieve(id);
            Assert.NotNull(result);
            Assert.AreEqual(expectedLastname, result.LastName);
        }

        [TestCase(3, ExpectedException = typeof(System.Data.SqlClient.SqlException))]
        public void Update_WithScenarioDataInDatabaseAndLastNameIsInvalid_ExpectSqlException(
            int id)
        {
            // Arrange
            var classUnderTest = new IndividualDal(ConnectionString);

            var entity = classUnderTest.Retrieve(id);
            Assert.NotNull(entity);

            entity.LastName = null;

            // Act
            classUnderTest.Update(entity);

            // Assert
            Assert.Fail("Expected an exception");
        }
    }
}
