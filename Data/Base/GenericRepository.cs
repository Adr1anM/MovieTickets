using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;
using System.Linq.Expressions;

namespace OnlineShop.Data.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
           _context.SaveChanges();
        
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges(); 
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int? id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> Update(int id, T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
