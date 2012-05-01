SAMPLE CODE: READ ME

For these instructions, it is assumed that the same code for this chaper is found in your C:\Samples\Ch12 folder.
In the instructions that follow your installation folder is referred to by a dollar symbol ($).

Create the "Lender.Slos" Database
=================================

The Database folder contains the database scripts to create the database.

For the sake of simplicity there are a few batch files that use MSBuild to run database scripts, automate the build, and automate running the tests. These batch files assume you defined the following environment variables:
	• MSBuildRoot – the path to MSBuild.exe
For example, C:\Windows\Microsoft.NET\Framework64\v4.0.30319

	• SqlToolsRoot – the path to sqlcmd.exe
For example, C:\Program Files\Microsoft SQL Server\100\Tools\Binn

The DbCreate.SqlExpress.Lender.Slos.bat command file creates the local SQLExpress database.

With the database created and the environment variables set, run the Lender.Slos.CreateScripts.bat batch to execute all the SQL create scripts in the correct order. If you prefer to run the scripts manually then you will find them in the $\Deploy\Database\Scripts\Create folder. The script_run_order.txt file lists the proper order to run the scripts. If all the scripts run properly there will be three tables (Individual, Student and Application) and twelve stored procedures (a set of four CRUD stored procedures for each of the tables) in the database.


Create the "Tests.Unit.Lender.Slos.Dal" Test Project
====================================================

To start, create a new Class Library project named "Tests.Unit.Lender.Slos.Dal", under the "Tests/Unit" folder.

	• Rename the "Class1" class to the "IndividualDalTests" class.

	• Add a reference to the NUnit framework.

	• Add a reference to the NDbUnit framework.
1) The "Core" assembly.
2) Since these tests are testing SQL Server, add a reference to the "SqlClient" assembly.


Create the DataSet
==================

Create a "Data" folder within the Tests… project. We're going to create the "Lender.Slos.DataSet.xsd" within this folder.

To start, right-click on the Data folder under the Tests.Unit.Lender.Slos.Dal
project.
	• Select the Add => New Item … from the context menu.

	• In the Add New Item window there is a Data template named DataSet. Provide the
name as "Lender.Slos.DataSet.xsd". Press the Add button. This adds the DataSet file to the project
and opens the designer window.

	• Browse to the "Lender.Slos" database from the Server Explorer in Visual Studio.

	• Drag the Individual table from the Server Explorer into the DataSet designer
surface, which adds it to the DataSet definition.

	• Save and close the DataSet designer.

Create the Tests XML Data
=========================

Create a new XML file and name it "IndividualDalTests_Scenario01.xml"
	• Select the Add => New Item … from the context menu.

	• In the Add New Item window there is an XML File template. Provide the
name as "IndividualDalTests_Scenario01.xml". Press the Add button. This adds the XML file to the project
and opens the editor.

	• Select the Add => New Item … from the context menu.

	• Replace the XML content of the file, as follows:

<?xml version="1.0" standalone="yes"?>
<Lender xmlns="http://tempuri.org/Lender.xsd">
  <Individual>
    <Id>1</Id>
    <LastName>Roosevelt</LastName>
    <FirstName>Theodore</FirstName>
    <MiddleName />
    <Suffix />
    <DateOfBirth>1858-10-27</DateOfBirth>
  </Individual>
  <Individual>
    <Id>3</Id>
    <LastName>Smith</LastName>
    <FirstName>John</FirstName>
    <MiddleName>Q</MiddleName>
    <Suffix>Sr.</Suffix>
    <DateOfBirth>2011-01-01</DateOfBirth>
  </Individual>
  <Individual>
    <Id>5</Id>
    <LastName>Truman</LastName>
    <FirstName>Harry</FirstName>
    <MiddleName>S</MiddleName>
    <Suffix />
    <DateOfBirth>1884-05-08</DateOfBirth>
  </Individual>
</Lender>

	• Save and close the XML file.


Create the First Test Method
============================

Write a new test method within the "IndividualDalTests" class.

	• Name the method "Retrieve_WithIdOf3_ExpectLastNameOfSmith".

	• Add the 3A sections; arrange, act, assert

	• The Arrange section instantiates the class-under-test, which is the IndividualDal class.

	• The Act section calls the Retrieve method on the class-under-test instance with an Id of 3.

	• The Assert section verifies that the actual entity is not null and the LastName property is "Smith".

	• When you're done the test class file might look something like this:

using Lender.Slos.Dal;

namespace Tests.Unit.Lender.Slos.Dal
{
    using NUnit.Framework;

    public class IndividualDalTests
    {
        [Test]
        public void Retrieve_WithIdOf3_ExpectLastNameOfSmith()
        {
            // Arrange
            var classUnderTest =
                new IndividualDal(
                    @"Data Source=(local)\SQLExpress;Initial Catalog=Lender.Slos;Integrated Security=True");

            // Act
            var actual = classUnderTest.Retrieve(3);

            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual("Smith", actual.LastName);
        }
    }
}


Watch the Test Method Fail
==========================

Option 1: Assuming you're using the ReSharper, DevExpress, NUnit GUI, Gallio, TestDriven.NET, or any of a number or test runners; run the test.

Option 2: Run the test with the "Runner.bat" file provided, by adding the "Test" target to the /t parameter. The command line should look like this:

	%MSBuildRoot%\msbuild.exe "runner.msbuild" /l:FileLogger,Microsoft.Build.Engine;logfile=runner.log /t:Rebuild;Test /p:Configuration=Debug


	• The test method ought to fail with an output similar to this:

  Errors and Failures:
  1) Test Failure : Tests.Unit.Lender.Slos.Dal.IndividualDalTests.Retrieve_WithIdOf3_ExpectLastNameOfSmith
       Expected: not null
	   But was:  null
  


Add the NDbUnit Scaffolding
===========================

	• Add a private field to hold the INDbUnitTest variable. This is the NDbUnit instance. 

	• Add a "Fixture Setup" method. Within this method, instantiate the NDbUnit provider, load the XML schema, and load the XML data.

	• Add a "Fixture Teardown" method. When all the tests are done, this method uses NDbUnit to clear the database of all data.

	• Add a test method "Setup" method. Before each test is run, this method uses NDbUnit to put the database into the "known state".

	• When you're done the test class file might look something like this:

using Lender.Slos.Dal;
using NDbUnit.Core.SqlClient;

namespace Tests.Unit.Lender.Slos.Dal
{
    using NDbUnit.Core;
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
        public void Setup()
        {
            _database.PerformDbOperation(DbOperationFlag.CleanInsertIdentity);
        }

        [Test]
        public void Retrieve_WithIdOf3_ExpectLastNameOfSmith()
        {
            // Arrange
            var classUnderTest = new IndividualDal(ConnectionString);

            // Act
            var actual = classUnderTest.Retrieve(3);

            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual("Smith", actual.LastName);
        }
    }
}


Watch the Test Method Pass
==========================


	• The test method passes with an output similar to this:

  Tests run: 1, Errors: 0, Failures: 0, Inconclusive: 0, Time: 2.7521574 seconds
    Not run: 0, Invalid: 0, Ignored: 0, Skipped: 0
