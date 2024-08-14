using eTickets.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace eTickets.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _context;
        public EntityBaseRepository(AppDbContext context)
        {
                _context = context;
        }
        public async Task AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()=> await _context.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> values = _context.Set<T>();
            values = includeProperties.Aggregate(values, (current, includeProperties) => current.Include(includeProperties));
            return await values.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)=> await _context.Set<T>().SingleOrDefaultAsync(x => x.Id == id);

        public Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
