using MediatR;
using Persons.Domain.Dtos;

namespace Persons.Application.Person.Commands
{
    public class UpdatePersonCommand : PersonDto, IRequest
    {
    }
}
