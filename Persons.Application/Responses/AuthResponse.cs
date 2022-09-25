using Persons.Domain.Dtos;

namespace Persons.Application.Responses
{
    public class AuthResponse : ApiResponse
    {
        public UserDto User { get; set; } = default!;
    }
}
