using Persons.Domain.DomainException;
using Persons.Domain.Entities;
using Persons.Domain.Ports;

namespace Persons.Domain.Services
{
    [DomainService]
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _genericRepository;
        public UserService(IGenericRepository<User> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<User> Auth(string userName, string password)
        {
            User? user = await _genericRepository.GetAsync(x => x.Id.Equals(userName) && x.Password.Equals(password), "Scopes");
            if (user == null) throw new AuthException("User does not exist.");
            return user;
        }
    }
}
