using Persons.Domain.Entities;
using System.Security.Claims;

namespace Persons.Domain.Ports
{
    public interface IJWTRepository
    {
        string Authenticate(User user);
        IEnumerable<Claim> ValidateToken(string accessToken);
    }
}
