using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityApp.BLL.RequestViewModel;
using UniversityApp.DLL.Models;
using UniversityApp.DLL.Repository;
using UniversityApp.DLL.UOW;

namespace UniversityApp.BLL.Services
{
    public interface IDepartmentService
    {
        Task<Department> InsertAsyce(DepartmentInsertRequestViewModel request);
        Task<List<Department>> GetAllAsync();
        Task<Department> DeleteAsync(string departmentCode);
        Task<Department> GetAAsync(string departmentCode);
    }

    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IDepartmentRepository departmentRepository,IUnitOfWork unitOfWork)
        {
            _departmentRepository = departmentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Department> InsertAsyce(DepartmentInsertRequestViewModel request)
        {
            var department = new Department()
            {
                Code = request.Code,
                Name = request.Name
            };

            await _departmentRepository.CreateAsync(department);
            await _unitOfWork.Commit();
            return department;
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _departmentRepository.QueryAll().ToListAsync();
        }

        public Task<Department> DeleteAsync(string departmentCode)
        {
            throw new System.NotImplementedException();
        }

        public Task<Department> GetAAsync(string departmentCode)
        {
            throw new System.NotImplementedException();
        }
    }
}