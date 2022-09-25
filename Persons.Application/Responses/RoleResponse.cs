namespace Persons.Application.Responses
{
    public class RoleResponse : ApiResponse
    {
        public List<string> Scopes { get; set; } = default!;
    }
}
