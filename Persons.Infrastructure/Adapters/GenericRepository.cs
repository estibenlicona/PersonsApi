using Microsoft.EntityFrameworkCore;
using Persons.Domain.Entities.Base;
using Persons.Domain.Ports;
using Persons.Infrastructure.Contexts;
using System.Linq.Expressions;

namespace Persons.Infrastructure.Adapters
{
    public class GenericRepository<E> : IGenericRepository<E> where E : DomainEntity
    {
        private readonly PersistenceContext _context;
        public GenericRepository(PersistenceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<E?> GetAsync(Expression<Func<E, bool>> filter, string includeStringProperties = "")
        {
            IQueryable<E> query = _context.Set<E>();

            if (!string.IsNullOrEmpty(includeStringProperties))
            {
                foreach (var includeProperty in includeStringProperties.Split
                    (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            query = query.Where(filter);
            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Tuple<IEnumerable<E>, int>> ListAsync(int skip = 0, int take = 0, Expression<Func<E, bool>>? filter = null)
        {
            IQueryable<E> query = _context.Set<E>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            int count = query.Count();

            if (take > 0)
            {
                query = query.Skip(skip * take).Take(take);
            }

            return new Tuple<IEnumerable<E>, int>(await query.AsNoTracking().ToListAsync(), count);
        }

        public async Task UpdateAsync(E entity)
        {
            if (entity != null)
            {
                _context.Set<E>().Update(entity);
                await _context.CommitAsync();
            }
        }

        public async Task<E> AddAsync(E entity)
        {
            _ = entity ?? throw new ArgumentNullException(nameof(entity), "Entity can not be null");
            _context.Set<E>().Add(entity);
            await _context.CommitAsync();
            return entity;
        }

        public async Task DeleteAsync(E entity)
        {
            if (entity != null)
            {
                _context.Set<E>().Remove(entity);
                await _context.CommitAsync();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            this._context.Dispose();
        }
    }
}
