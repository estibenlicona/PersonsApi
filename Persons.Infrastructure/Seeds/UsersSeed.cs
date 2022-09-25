using Persons.Domain.Entities;

namespace Persons.Infrastructure.Seeds
{
    public static class UsersSeed
    {
        public static IEnumerable<User> GetUsers()
        {
            return new List<User>()
            {
                new User("admin", "Administrador", "202cb962ac59075b964b07152d234b70")
            };
        }

    }
}
