using Persons.Domain.Entities.Base;

namespace Persons.Domain.Entities
{
    public class Person : EntityBase<Guid>
    {
        public string Document { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public Person()
        {

        }
        public Person(Guid id,string document, string firstName, string lastName)
        {
            Id = id;
            Document = document;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
