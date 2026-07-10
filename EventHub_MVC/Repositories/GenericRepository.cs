using EventHub_MVC.Data;
using EventHub_MVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventHub_MVC.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDBContext _context;
        protected readonly DbSet<T> _table;

        public GenericRepository(AppDBContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync() => await _table.ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _table.FindAsync(id);

        public async Task AddAsync(T entity) => await _table.AddAsync(entity);

        public void Update(T entity) => _context.Entry(entity).State = EntityState.Modified;

        public void Delete(T entity) => _table.Remove(entity);

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
