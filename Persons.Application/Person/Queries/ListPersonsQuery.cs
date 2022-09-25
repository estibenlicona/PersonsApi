using MediatR;
using Persons.Application.Responses;

namespace Persons.Application.Person.Queries
{
    public class ListPersonsQuery : IRequest<ListPersonsResponse>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
