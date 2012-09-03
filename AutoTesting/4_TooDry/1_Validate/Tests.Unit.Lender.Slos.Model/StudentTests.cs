using System;

using Lender.Slos.Dao;
using Lender.Slos.Model;

using Moq;

using NUnit.Framework;

namespace Tests.Unit.Lender.Slos.Model
{
    public class StudentTests
    {
        [Test]
        public void given_today_is_20150517_given_student_dob_1999_05_17_when_validated_expect_no_exception()
        {
            // Arrange
            var classUnderTest =
                new Student(null, null)
                {
                    Today = new DateTime(2015, 5, 17),
                    DateOfBirth = new DateTime(1999, 5, 17),
                };

            // Act
            classUnderTest.Validate();

            // Assert
            Assert.Pass("No exception thrown.");
        }

        [Test]
        public void given_today_is_2015_05_17_given_student_dob_19990516_when_validated_expect_no_exception()
        {
            // Arrange
            var classUnderTest =
                new Student(null, null)
                {
                    Today = new DateTime(2015, 5, 17),
                    DateOfBirth = new DateTime(1999, 5, 16),
                };

            // Act
            classUnderTest.Validate();

            // Assert
            Assert.Pass("No exception thrown.");
        }

        [Test]
        public void given_today_is_2015_05_17_given_student_dob_19990519_when_validated_expect_no_exception()
        {
            // Arrange
            var classUnderTest =
                new Student(null, null)
                {
                    Today = new DateTime(2015, 5, 17),
                    DateOfBirth = new DateTime(1999, 3, 19),
                };

            // Act
            classUnderTest.Validate();

            // Assert
            Assert.Pass("No exception thrown.");
        }

        [Test]
        public void given_today_is_2015_05_17_given_student_dob_19930517_when_validated_expect_no_exception()
        {
            // Arrange
            var classUnderTest =
                new Student(null, null)
                {
                    Today = new DateTime(2015, 5, 17),
                    DateOfBirth = new DateTime(1993, 5, 17),
                };

            // Act
            classUnderTest.Validate();

            // Assert
            Assert.Pass("No exception thrown.");
        }

        [Test]
        public void given_today_is_2015_05_17_given_student_dob_19890518_when_validated_expect_no_exception()
        {
            // Arrange
            var classUnderTest =
                new Student(null, null)
                {
                    Today = new DateTime(2015, 5, 17),
                    DateOfBirth = new DateTime(1989, 5, 18),
                };

            // Act
            classUnderTest.Validate();

            // Assert
            Assert.Pass("No exception thrown.");
        }

        [Test]
        public void given_today_is_2015_05_17_given_student_dob_19890519_when_validated_expect_no_exception()
        {
            // Arrange
            var classUnderTest =
                new Student(null, null)
                {
                    Today = new DateTime(2015, 5, 17),
                    DateOfBirth = new DateTime(1989, 5, 19),
                };

            // Act
            classUnderTest.Validate();

            // Assert
            Assert.Pass("No exception thrown.");
        }

        [Test]
        public void given_today_is_2015_05_17_given_student_dob_19990518_when_validated_expect_InvalidOperationException()
        {
            // Arrange
            var classUnderTest =
                new Student(null, null)
                {
                    Today = new DateTime(2015, 5, 17),
                    DateOfBirth = new DateTime(1999, 5, 18),
                };

            // Act
            TestDelegate act = () => classUnderTest.Validate();

            // Assert
            Assert.Throws<InvalidOperationException>(act,
                "Exception was not thrown for DOB {0} applying on {1}",
                classUnderTest.DateOfBirth.ToShortDateString(),
                classUnderTest.Today.ToShortDateString());
        }

        [Test]
        public void given_today_is_2015_05_17_given_student_dob_20030719WhenValidatedExpectInvalidOperationException()
        {
            // Arrange
            var classUnderTest =
                new Student(null, null)
                {
                    Today = new DateTime(2015, 5, 17),
                    DateOfBirth = new DateTime(2003, 7, 19),
                };

            // Act
            TestDelegate act = () => classUnderTest.Validate();

            // Assert
            Assert.Throws<InvalidOperationException>(act,
                "Exception was not thrown for DOB {0} applying on {1}",
                classUnderTest.DateOfBirth.ToShortDateString(),
                classUnderTest.Today.ToShortDateString());
        }

        [Test]
        public void given_today_is_2015_05_17_given_student_dob_19890517WhenValidatedExpectInvalidOperationException()
        {
            // Arrange
            var classUnderTest =
                new Student(null, null)
                {
                    Today = new DateTime(2015, 5, 17),
                    DateOfBirth = new DateTime(1989, 5, 17),
                };

            // Act
            TestDelegate act = () => classUnderTest.Validate();

            // Assert
            Assert.Throws<InvalidOperationException>(act,
                "Exception was not thrown for DOB {0} applying on {1}",
                classUnderTest.DateOfBirth.ToShortDateString(),
                classUnderTest.Today.ToShortDateString());
        }

        [Test]
        public void given_today_is_2015_05_17_given_student_dob_19890516WhenValidatedExpectInvalidOperationException()
        {
            // Arrange
            var classUnderTest =
                new Student(null, null)
                {
                    Today = new DateTime(2015, 5, 17),
                    DateOfBirth = new DateTime(1989, 5, 16),
                };

            // Act
            TestDelegate act = () => classUnderTest.Validate();

            // Assert
            Assert.Throws<InvalidOperationException>(act,
                "Exception was not thrown for DOB {0} applying on {1}",
                classUnderTest.DateOfBirth.ToShortDateString(),
                classUnderTest.Today.ToShortDateString());
        }

        [Test]
        public void given_today_is_2015_05_17_given_student_dob_19510719WhenValidatedExpectInvalidOperationException()
        {
            // Arrange
            var classUnderTest =
                new Student(null, null)
                {
                    Today = new DateTime(2015, 5, 17),
                    DateOfBirth = new DateTime(1951, 7, 19),
                };

            // Act
            TestDelegate act = () => classUnderTest.Validate();

            // Assert
            Assert.Throws<InvalidOperationException>(act,
                "Exception was not thrown for DOB {0} applying on {1}",
                classUnderTest.DateOfBirth.ToShortDateString(),
                classUnderTest.Today.ToShortDateString());
        }

        [Test]
        public void given_today_is_2015_05_17_given_student_dob_20150517WhenValidatedExpectInvalidOperationException()
        {
            // Arrange
            var classUnderTest =
                new Student(null, null)
                {
                    Today = new DateTime(2015, 5, 17),
                    DateOfBirth = new DateTime(2015, 5, 17),
                };

            // Act
            TestDelegate act = () => classUnderTest.Validate();

            // Assert
            Assert.Throws<InvalidOperationException>(act,
                "Exception was not thrown for DOB {0} applying on {1}",
                classUnderTest.DateOfBirth.ToShortDateString(),
                classUnderTest.Today.ToShortDateString());
        }

        [Test]
        public void given_today_is_2015_05_17_given_student_dob_20150518WhenValidatedExpectInvalidOperationException()
        {
            // Arrange
            var classUnderTest =
                new Student(null, null)
                {
                    Today = new DateTime(2015, 5, 17),
                    DateOfBirth = new DateTime(2015, 5, 18),
                };

            // Act
            TestDelegate act = () => classUnderTest.Validate();

            // Assert
            Assert.Throws<InvalidOperationException>(act,
                "Exception was not thrown for DOB {0} applying on {1}",
                classUnderTest.DateOfBirth.ToShortDateString(),
                classUnderTest.Today.ToShortDateString());
        }

        [Test]
        public void GivenAgeOf47WhenSavingThenExpectInvalidOperationException()
        {
            // Arrange
            var today = new DateTime(2003, 5, 17);

            var classUnderTest =
                new Student(null, null)
                {
                    Today = today,
                    DateOfBirth = today.AddYears(-1 * 47),
                };

            // Act
            TestDelegate act = () => classUnderTest.Save();

            // Assert
            Assert.Throws<InvalidOperationException>(act,
                "Exception was not thrown for age {0}", 47);
        }

        [Test]
        public void GivenStudentAgeOf13WhenSavingExpectInvalidOperationException()
        {
            // Arrange
            var today = new DateTime(2003, 5, 17);

            var classUnderTest =
                new Student(null, null)
                {
                    Today = today,
                    DateOfBirth = today.AddYears(-1 * 13),
                };

            // Act
            TestDelegate act = () => classUnderTest.Save();

            // Assert
            Assert.Throws<InvalidOperationException>(act,
                "Exception was not thrown for age {0}", 13);
        }

        [Test]
        public void GivenValidNewStudentWhenSavedExpectIndividualDalCreateIsCalledOnce()
        {
            // Arrange
            var today = new DateTime(2003, 5, 17);

            const int expectedStudentId = 897931;

            var stubStudentRepo = new Mock<IRepository<StudentEntity>>();
            stubStudentRepo
                .Setup(e => e.Retrieve(expectedStudentId))
                .Returns(default(StudentEntity));
            stubStudentRepo
                .Setup(e => e.Create(It.IsAny<StudentEntity>()))
                .Returns(expectedStudentId);

            var mockIndividualRepo = new Mock<IRepository<IndividualEntity>>();
            mockIndividualRepo
                .Setup(e => e.Create(It.IsAny<IndividualEntity>()))
                .Returns(expectedStudentId);

            var classUnderTest =
                new Student(mockIndividualRepo.Object, stubStudentRepo.Object)
                {
                    Today = today,
                    DateOfBirth = today.AddYears(-19),
                };

            // Act
            classUnderTest.Save();

            // Assert
            Assert.AreEqual(expectedStudentId, classUnderTest.Id);
            mockIndividualRepo
                .Verify(e => e.Create(It.IsAny<IndividualEntity>()), Times.Once());
        }

        [Test]
        public void GivenAnExistingStudentWhenSavedExpectIndividualDalUpdateIsCalledOnce()
        {
            // Arrange
            var today = new DateTime(2003, 5, 17);

            const int expectedStudentId = 897931;
            var studentEntity = new StudentEntity { Id = expectedStudentId, };

            var stubStudentRepo = new Mock<IRepository<StudentEntity>>();
            stubStudentRepo
                .Setup(e => e.Retrieve(expectedStudentId))
                .Returns(studentEntity);

            var mockIndividualRepo = new Mock<IRepository<IndividualEntity>>();
            mockIndividualRepo
                .Setup(e => e.Update(It.IsAny<IndividualEntity>()));

            var classUnderTest =
                new Student(mockIndividualRepo.Object, stubStudentRepo.Object)
                {
                    Id = expectedStudentId,
                    Today = today,
                    DateOfBirth = today.AddYears(-19),
                };

            // Act
            classUnderTest.Save();

            // Assert
            Assert.AreEqual(expectedStudentId, classUnderTest.Id);
            mockIndividualRepo
                .Verify(e => e.Update(It.IsAny<IndividualEntity>()), Times.Once());
        }

        [Test]
        public void GivenAnExistingStudentWhenImproperlyCreatedWhenSavedExpectInvalidOperationException()
        {
            // Arrange
            var today = new DateTime(2003, 5, 17);

            const int expectedStudentId = 897931;

            var stubIndividualRepo = new Mock<IRepository<IndividualEntity>>();
            stubIndividualRepo
                .Setup(e => e.Update(It.IsAny<IndividualEntity>()));

            var stubStudentRepo = new Mock<IRepository<StudentEntity>>();
            stubStudentRepo
                .Setup(e => e.Retrieve(expectedStudentId))
                .Returns(default(StudentEntity));
            stubStudentRepo
                .Setup(e => e.Create(It.IsAny<StudentEntity>()))
                .Returns(23);

            var classUnderTest =
                new Student(stubIndividualRepo.Object, stubStudentRepo.Object)
                {
                    Id = expectedStudentId,
                    Today = today,
                    DateOfBirth = today.AddYears(-19),
                };

            // Act
            TestDelegate act = () => classUnderTest.Save();

            // Assert
            Assert.Throws<InvalidOperationException>(act);
        }
    }
}
