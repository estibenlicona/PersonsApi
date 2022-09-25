using MediatR;
using Persons.Application.Scope.Queries;
using Persons.Domain.Exceptions;
using Persons.Domain.Ports;
using System.Security.Claims;

namespace Persons.Application.Scope.Handlers
{
    public class GetScopesQueryHandler : IRequestHandler<GetScopesQuery, List<string>>
    {
        private readonly IGenericRepository<Domain.Entities.Scope> _genericRepository;
        private readonly IJWTRepository _jWTRepository;
        public GetScopesQueryHandler(IGenericRepository<Domain.Entities.Scope> genericRepository, IJWTRepository jWTRepository)
        {
            _genericRepository = genericRepository;
            _jWTRepository = jWTRepository;
        }
        public async Task<List<string>> Handle(GetScopesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Claim> claims = _jWTRepository.ValidateToken(request.AccessToken);
            string? userId = claims.SingleOrDefault(c => c.Type == "nameid")?.Value;
            if (userId == null) throw new AppException("Claims error.");
            Tuple<IEnumerable<Domain.Entities.Scope>, int> tuple = await _genericRepository.ListAsync(filter: x => x.UserId.Equals(userId));
            List<string> scopes = tuple.Item1.Select(x => x.Name).ToList();
            return scopes;
        }
    }
}
