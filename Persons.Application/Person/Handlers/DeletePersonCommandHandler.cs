using AutoMapper;
using MediatR;
using Persons.Application.Person.Commands;
using Persons.Domain.Ports;

namespace Persons.Application.Person.Handlers
{
    public class DeletePersonCommandHandler : AsyncRequestHandler<DeletePersonCommand>
    {
        private readonly IPersonService _personService;
        public DeletePersonCommandHandler(IPersonService personService)
        {
            _personService = personService;
        }
        protected override async Task Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            await _personService.DeleteAsync(new Domain.Entities.Person { Id = request.Id });
        }
    }
}
