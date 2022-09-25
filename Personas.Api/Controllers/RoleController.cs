using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persons.Application.Responses;
using Persons.Application.Scope.Queries;

namespace Persons.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<RoleResponse> Get()
        {
            var access_token = Request.Headers.Authorization.ToString().Replace("Bearer ", string.Empty);
            List<string> scopes = await _mediator.Send(new GetScopesQuery { AccessToken = access_token });
            return new RoleResponse
            {
                Message = "Scopes obtained successfully.",
                Scopes = scopes
            };
        }
    }
}
