using AutoMapper;
using MediatR;
using Persons.Application.Person.Commands;
using Persons.Domain.Ports;

namespace Persons.Application.Person.Handlers
{
    public class UpdatePersonCommandHandler : AsyncRequestHandler<UpdatePersonCommand>
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;
        public UpdatePersonCommandHandler(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }
        protected override async Task Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Person person = _mapper.Map<Domain.Entities.Person>(request);
            await _personService.UpdateAsync(person);
        }
    }
}
