using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persons.Application.Person.Commands;
using Persons.Application.Person.Queries;
using Persons.Application.Responses;

namespace Personas.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ListPersonsResponse> List([FromQuery] ListPersonsQuery listPersonsQuery)
        {
            ListPersonsResponse response = await _mediator.Send(listPersonsQuery);
            response.Message = "Records uploaded successfully.";
            return response;
        }

        [HttpPost]
        public async Task<AddPersonResponse> Add([FromBody] AddPersonCommand addPersonCommand)
        {
            return new AddPersonResponse { 
                Message = "Successful registration.", 
                Id = await _mediator.Send(addPersonCommand) 
            };
        }

        [HttpPut]
        public async Task<ApiResponse> Update([FromBody] UpdatePersonCommand updatePersonCommand)
        {
            await _mediator.Send(updatePersonCommand);
            return new ApiResponse
            {
                Message = "Registry updated successfully."
            };
        }

        [HttpDelete("{id}")]
        public async Task<ApiResponse> Delete(string id)
        {
            await _mediator.Send(new DeletePersonCommand { Id = new Guid(id) });
            return new ApiResponse
            {
                Message = "Registry deleted successfully."
            };
        }
    }
}