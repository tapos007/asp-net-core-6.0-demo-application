using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityApp.DLL.Context;

namespace UniversityApp.DLL.Repository
{
    public interface IRepository<T> : IDisposable where T:class
    {
        IQueryable<T> QueryAll(Expression<Func<T, bool>> expression = null);
        Task CreateAsync(T entry);
        Task CreateAsync(List<T> entry);
        void UpdateAsync(T entry);
        void UpdateAsync(List<T> entry);
        void DeleteAsync(T entry);
        void DeleteAsync(List<T> entry);
        Task<T> FindSingleAsync(Expression<Func<T, bool>> expression);
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext Db;
        protected readonly DbSet<T> DbSet;
        public Repository(ApplicationDbContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();

        }

        

        public IQueryable<T> QueryAll(Expression<Func<T, bool>> expression = null)
        {
            if (expression == null)
            {
                return DbSet.AsQueryable().AsNoTracking();
            }
            return DbSet.AsQueryable().Where(expression).AsNoTracking();
        }

        public async Task CreateAsync(T entry)
        {
             await DbSet.AddAsync(entry);
        }

        public async Task CreateAsync(List<T> entry)
        {
            await DbSet.AddRangeAsync(entry);
        }

        public void UpdateAsync(T entry)
        {
            DbSet.Update(entry);
        }

        public void UpdateAsync(List<T> entry)
        {
            DbSet.UpdateRange(entry);
        }

        public void DeleteAsync(T entry)
        {
            DbSet.Remove(entry);
        }

        public void DeleteAsync(List<T> entry)
        {
            DbSet.RemoveRange(entry);
        }

        public async Task<T> FindSingleAsync(Expression<Func<T, bool>> expression)
        {
            return await DbSet.FirstOrDefaultAsync(expression);
        }
        
        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}