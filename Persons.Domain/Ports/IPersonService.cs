using Persons.Domain.Entities;
using System.Linq.Expressions;

namespace Persons.Domain.Ports
{
    public interface IPersonService
    {
        Task<Tuple<IEnumerable<Person>, int>> ListAsync(int skip = 0, int take = 0, Expression<Func<Person, bool>>? filter = null);
        Task<Guid> AddAsync(Person entity);
        Task UpdateAsync(Person entity);
        Task DeleteAsync(Person entity);
    }
}
