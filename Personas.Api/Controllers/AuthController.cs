using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persons.Application.Auth.Queries;
using Persons.Application.Responses;

namespace Persons.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<AuthResponse> Auth([FromBody] AuthUserQuery authUserQuery)
        {
            return new AuthResponse
            {
                Message = "Successfully authenticated user.",
                User = await _mediator.Send(authUserQuery)
            };
        }

    }
}
