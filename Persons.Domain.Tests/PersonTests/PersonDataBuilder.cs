using Persons.Domain.Entities;

namespace Persons.Domain.Tests.PersonTests
{
    public class PersonDataBuilder
    {
        Guid Id = default!;
        string Document = default!;
        string FirstName = default!;
        string LastName = default!;

        public Person Build()
        {
            Person person = new Person(Id, Document, FirstName, LastName);
            return person;
        }

        public PersonDataBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public PersonDataBuilder WithDocument(string document)
        {
            Document = document;
            return this;
        }

        public PersonDataBuilder WithFirstName(string firstName)
        {
            FirstName = firstName;
            return this;
        }

        public PersonDataBuilder WithLastName(string lastName)
        {
            LastName = lastName;
            return this;
        }

    }
}
