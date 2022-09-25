using Persons.Domain.Entities;

namespace Persons.Domain.Ports
{
    public interface IUserService
    {
        Task<User> Auth(string userName, string password);
    }
}
