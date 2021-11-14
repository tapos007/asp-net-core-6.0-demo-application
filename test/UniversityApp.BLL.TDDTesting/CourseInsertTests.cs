using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentValidation.TestHelper;
using Moq;
using UniversityApp.BLL.Services;
using UniversityApp.BLL.ViewModel;
using UniversityApp.DLL.Models;
using UniversityApp.DLL.Repository;
using UniversityApp.DLL.UOW;
using Xunit;

namespace UniversityApp.BLL
{
    public class CourseInsertTests
    {
        private readonly Mock<ICourseRepository> _courseRepositoryMock;
        private readonly CourseService _courseService;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public CourseInsertTests()
        {
            _courseRepositoryMock = new Mock<ICourseRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _courseService = new CourseService(_courseRepositoryMock.Object, _unitOfWorkMock.Object);
        }

        [Fact]
        public async Task ShouldReturnCourseWithRequestResponseValue()
        {
            // Arrange
            var request = new CourseInsertRequestViewModel()
            {
                Name = "object oriented programming",
                Code = "cs001",
                Credit = 2.0
            };


            // Act
            CourseInsertResponseViewModel response = await _courseService.CreateCourseAsync(request);

            // Arrange 

            Assert.NotNull(response);
            Assert.Equal(request.Name, response.Name);
            Assert.Equal(request.Code, response.Code);
            Assert.Equal(request.Credit, response.Credit);
        }

        [Fact]
        public async Task ShouldThrowExceptionIfRequestIsNull()
        {
            var exception =
                await Assert.ThrowsAsync<ArgumentNullException>(() => _courseService.CreateCourseAsync(null));

            Assert.Equal("request", exception.ParamName);
        }

        [Fact]
        public async Task ShouldFluentValidatorSetupError()
        {
            var request = new CourseInsertRequestViewModel()
            {
            };
            var validator = new CourseInsertRequestViewModelValidator();

            var result = await validator.TestValidateAsync(request);

            result.ShouldHaveValidationErrorFor(x => x.Name);
            result.ShouldHaveValidationErrorFor(x => x.Code);
            result.ShouldHaveValidationErrorFor(x => x.Credit);
        }

        [Fact]
        public async Task ShouldSaveCourseInDatabase()
        {
            var request = new CourseInsertRequestViewModel()
            {
                Name = "object oriented programming",
                Code = "cs001",
                Credit = 2.0
            };

            var response = await _courseService.CreateCourseAsync(request);

            _courseRepositoryMock.Verify(x => x.CreateAsync(It.IsAny<Course>()), Times.Once);
            _unitOfWorkMock.Verify(x => x.Commit(), Times.Once);

            Assert.NotNull(response);
            Assert.Equal(request.Code, response.Code);
            Assert.Equal(request.Name, response.Name);
            Assert.Equal(request.Credit, response.Credit);
        }

        [Fact]
        public async Task ShouldNotSaveCourseIfCodeOrNameAlreadyInSystem()
        {
            var request = new CourseInsertRequestViewModel()
            {
                Name = "object oriented programming",
                Code = "cs001",
                Credit = 2.0
            };

            var courseData = new Course()
            {
                Code = "cs001",
                Name = "java how to program",
                Credit = 3
            };

            _courseRepositoryMock.Setup(x => x.FindSingleAsync(It.IsAny<Expression<Func<Course, bool>>>()))
                .ReturnsAsync(courseData);

            _courseRepositoryMock.Verify(x => x.CreateAsync(It.IsAny<Course>()), Times.Never);
            _unitOfWorkMock.Verify(x => x.Commit(), Times.Never);
            var exception = await Assert.ThrowsAsync<Exception>(() => _courseService.CreateCourseAsync(request));
            Assert.Equal("data already in our system",exception.Message);
            
            
        }
    }
}