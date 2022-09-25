using AutoMapper;
using MediatR;
using Persons.Application.Person.Commands;
using Persons.Domain.Ports;

namespace Persons.Application.Person.Handlers
{
    public class AddPersonCommandHandler : IRequestHandler<AddPersonCommand, Guid>
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;
        public AddPersonCommandHandler(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Person person = _mapper.Map<Domain.Entities.Person>(request);
            return await _personService.AddAsync(person);
        }
    }
}
