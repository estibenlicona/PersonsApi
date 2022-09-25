using Persons.Domain.Entities;

namespace Persons.Infrastructure.Seeds
{
    public static class ScopeSeed
    {
        public static IEnumerable<Scope> GetScopes()
        {
            return new List<Scope>()
            {
                new Scope(Guid.NewGuid(), "admin", "Persons.Read"),
                new Scope(Guid.NewGuid(), "admin", "Persons.Create"),
                new Scope(Guid.NewGuid(), "admin", "Persons.Edit"),
                new Scope(Guid.NewGuid(), "admin", "Persons.Delete")
            };
        }
    }
}
