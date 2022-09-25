using MediatR;
using Persons.Domain.Dtos;

namespace Persons.Application.Auth.Queries
{
    public class AuthUserQuery : IRequest<UserDto>
    {
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
