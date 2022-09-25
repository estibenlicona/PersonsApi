namespace Persons.Domain.Dtos
{
    public class PersonDto
    {
        public Guid Id { get; set; } = default!;
        public string Document { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
    }
}
