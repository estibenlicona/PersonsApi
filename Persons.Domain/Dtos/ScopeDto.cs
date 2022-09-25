using Persons.Domain.Entities;

namespace Persons.Domain.Dtos
{
    public class ScopeDto
    {
        public Guid Id { get; set; } = default!;
        public string UserId { get; set; } = default!;
        public User User { get; set; } = default!;
        public string Name { get; set; } = default!;
    }
}
