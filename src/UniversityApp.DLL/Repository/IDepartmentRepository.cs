using UniversityApp.DLL.Context;
using UniversityApp.DLL.Models;

namespace UniversityApp.DLL.Repository
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        
    }

    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}