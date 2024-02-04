using API.Data;
using Core.Entities;
using Core.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
         private StoreContext _context;

        public GenericRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<T> GetById(int id)
        {
           return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetList()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}