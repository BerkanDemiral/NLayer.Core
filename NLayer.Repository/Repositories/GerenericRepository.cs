using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class GerenericRepository<T> : IGenericRepository<T> where T : class
    {
        // I Specified readonly for Db Properties. Because i dont want set to properies other funcitons. I should only specify in constructor method.

        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GerenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>(); 
        }

        public async Task AddAsync(T entity) // used async beacuese won't return a value. therefore used await in method. await is not process in for db only used memory
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);   
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _dbSet.AsNoTracking().AsQueryable(); // AsNoTracking() -> the data shouldn't be stored in the memory therefore stored for processing with arrow functions
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id); 
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity); // remove only specified entity's enumerable status. Dont process for db or memory. Therefore not need async
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
