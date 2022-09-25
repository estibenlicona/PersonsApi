using Persons.Domain.Entities.Base;

namespace Persons.Domain.Entities
{
    public class Scope : EntityBase<Guid>
    {
        public string UserId { get; set; } = default!;
        public User User { get; set; } = default!;
        public string Name { get; set; } = default!;
        public Scope()
        {

        }

        public Scope(Guid id, string userId, string name)
        {
            Id = id;
            UserId = userId;
            Name = name;

        }
    }
}
