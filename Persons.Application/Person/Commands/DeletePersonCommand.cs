using MediatR;

namespace Persons.Application.Person.Commands
{
    public class DeletePersonCommand : IRequest
    {
        public Guid Id { get; set; } = default!;
    }
}
