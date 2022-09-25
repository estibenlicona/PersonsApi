using Persons.Domain.Entities;
using Persons.Domain.Ports;
using System.Linq.Expressions;

namespace Persons.Domain.Services
{
    [DomainService]
    public class PersonService : IPersonService
    {
        private readonly IGenericRepository<Person> _genericRepository;

        public PersonService(IGenericRepository<Person> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Guid> AddAsync(Person entity)
        {
            Person person = await _genericRepository.AddAsync(entity);
            return person.Id;
        }

        public async Task DeleteAsync(Person entity)
        {
            await _genericRepository.DeleteAsync(entity);
        }

        public async Task<Tuple<IEnumerable<Person>, int>> ListAsync(int skip = 0, int take = 0, Expression<Func<Person, bool>>? filter = null)
        {
            return await _genericRepository.ListAsync(skip, take, filter);
        }

        public async Task UpdateAsync(Person entity)
        {
            await _genericRepository.UpdateAsync(entity);
        }
    }
}
