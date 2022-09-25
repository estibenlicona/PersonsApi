using Persons.Domain.Entities.Base;

namespace Persons.Domain.Entities
{
    public class User : EntityBase<string>
    {
        public string Name { get; set; } = default!;
        public string Password { get; set; } = default!;
        public List<Scope> Scopes { get; set; } = default!;
        public User()
        {

        }

        public User(string id, string name, string password)
        {
            Id = id;
            Name = name;
            Password = password;
        }
    }
}
