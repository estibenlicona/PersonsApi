using MediatR;

namespace Persons.Application.Scope.Queries
{
    public class GetScopesQuery : IRequest<List<string>>
    {
        public string AccessToken { get; set; } = default!;
    }
}
