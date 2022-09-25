namespace Persons.Domain.Dtos
{
    public class UserDto
    {
        public string Name { get; set; } = default!;
        public string AccessToken { get; set; } = default!;
        public List<string> Scopes { get; set; } = default!;
    }
}
