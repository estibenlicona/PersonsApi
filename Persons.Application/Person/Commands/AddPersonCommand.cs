using MediatR;
using Persons.Domain.Dtos;

namespace Persons.Application.Person.Commands
{
    public class AddPersonCommand : PersonDto, IRequest<Guid>
    {
    }
}
