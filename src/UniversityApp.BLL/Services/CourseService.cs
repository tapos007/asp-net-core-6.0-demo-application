using System;
using System.Threading.Tasks;
using UniversityApp.BLL.ViewModel;
using UniversityApp.DLL.Models;
using UniversityApp.DLL.Repository;
using UniversityApp.DLL.UOW;

namespace UniversityApp.BLL.Services
{
    public class CourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CourseInsertResponseViewModel> CreateCourseAsync(CourseInsertRequestViewModel request)
        {

            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }


            var existingData =
                await _courseRepository.FindSingleAsync(x => x.Code == request.Code || x.Name == request.Name);

            if (existingData != null)
            {
                throw new Exception("data already in our system");
            }
            
            var insertCourse = new Course()
            {
                Code = request.Code,
                Name = request.Name,
                Credit = request.Credit
            };

            await _courseRepository.CreateAsync(insertCourse);
            await _unitOfWork.Commit();
            
            
            return new CourseInsertResponseViewModel()
            {
                Code = request.Code,
                Name = request.Name,
                Credit = request.Credit,
                CourseId = insertCourse.Id
            };
        }
    }
}