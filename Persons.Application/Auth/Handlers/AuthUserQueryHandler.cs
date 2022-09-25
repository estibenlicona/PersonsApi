using AutoMapper;
using MediatR;
using Persons.Application.Auth.Queries;
using Persons.Domain.Dtos;
using Persons.Domain.Entities;
using Persons.Domain.Ports;

namespace Persons.Application.Auth.Handlers
{
    public class AuthUserQueryHandler : IRequestHandler<AuthUserQuery, UserDto>
    {
        private readonly IUserService _userService;
        private readonly IJWTRepository _jWTRepository;
        private readonly IMapper _mapper;

        public AuthUserQueryHandler(IUserService userService, IMapper mapper, IJWTRepository jWTRepository)
        {
            _userService = userService;
            _mapper = mapper;
            _jWTRepository = jWTRepository;
        }

        public async Task<UserDto> Handle(AuthUserQuery request, CancellationToken cancellationToken)
        {
            User user = await _userService.Auth(request.UserName, request.Password);
            UserDto userDto = _mapper.Map<UserDto>(user);
            userDto.AccessToken = _jWTRepository.Authenticate(user);

            return userDto;
        }
    }
}
