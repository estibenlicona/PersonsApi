using Persons.Domain.Dtos;

namespace Persons.Application.Responses
{
    public class ListPersonsResponse : ApiResponse
    {
        public int Count { get; set; } = default!;
        public IEnumerable<PersonDto> Persons { get; set; } = default!;
    }
}
