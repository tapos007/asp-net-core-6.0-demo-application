using System;
using System.Threading.Tasks;
using UniversityApp.DLL.Context;

namespace UniversityApp.DLL.UOW
{
    public interface IUnitOfWork :IDisposable
    {
        Task<bool> Commit();
    }
    
    public class  UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}