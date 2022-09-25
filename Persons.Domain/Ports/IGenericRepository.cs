using Persons.Domain.Entities.Base;
using System.Linq.Expressions;

namespace Persons.Domain.Ports
{
    public interface IGenericRepository<E> : IDisposable where E : DomainEntity
    {
        Task<E?> GetAsync(Expression<Func<E, bool>> filter, string includeStringProperties = "");
        Task<Tuple<IEnumerable<E>, int>> ListAsync(int page = 0, int size = 10, Expression<Func<E, bool>>? filter = null);
        Task<E> AddAsync(E entity);
        Task UpdateAsync(E entity);
        Task DeleteAsync(E entity);
    }
}
