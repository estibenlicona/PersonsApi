using AutoMapper;
using MediatR;
using Persons.Application.Person.Queries;
using Persons.Application.Responses;
using Persons.Domain.Dtos;
using Persons.Domain.Ports;

namespace Persons.Application.Person.Handlers
{
    public class ListPersonsQueryHandler : IRequestHandler<ListPersonsQuery, ListPersonsResponse>
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;
        public ListPersonsQueryHandler(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }
        public async Task<ListPersonsResponse> Handle(ListPersonsQuery request, CancellationToken cancellationToken)
        {
            Tuple<IEnumerable<Domain.Entities.Person>, int> list = await _personService.ListAsync(
                skip: request.Page, take: request.Size
            );

            IEnumerable<PersonDto> personsDto = _mapper.Map<IEnumerable<PersonDto>>(list.Item1);
            return new ListPersonsResponse { Persons = personsDto, Count = list.Item2 };
        }
    }
}
