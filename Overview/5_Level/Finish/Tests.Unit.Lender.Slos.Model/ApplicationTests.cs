using Lender.Slos.Dao;
using Lender.Slos.Model;
using Moq;
using NUnit.Framework;

namespace Tests.Unit.Lender.Slos.Model
{
    public class ApplicationTests
    {
        [Test]
        public void Get_WhenValidApplicationIsPassed_ExpectEntityHasProperId()
        {
            // Arrange
            const int id = 7;
            const int studentId = 11;

            var application =
                new ApplicationEntity
                    {
                        Id = id,
                        StudentId = studentId,
                    };
            var student = new StudentEntity { Id = studentId, };
            var individual = new IndividualEntity { Id = studentId, };

            var stubApplicationRepo = new Mock<IRepository<ApplicationEntity>>();
            stubApplicationRepo.Setup(e => e.Retrieve(id))
                .Returns(application);

            var stubStudentRepo = new Mock<IRepository<StudentEntity>>();
            stubStudentRepo.Setup(e => e.Retrieve(studentId))
                .Returns(student);

            var stubIndividualRepo = new Mock<IRepository<IndividualEntity>>();
            stubIndividualRepo.Setup(e => e.Retrieve(studentId))
                .Returns(individual);

            var classUnderTest = new Application(stubIndividualRepo.Object, stubStudentRepo.Object, stubApplicationRepo.Object);

            // Act
            classUnderTest.Get(id);

            // Assert
            var actual = classUnderTest.Id;
            Assert.AreEqual(id, actual);
        }
    }
}
