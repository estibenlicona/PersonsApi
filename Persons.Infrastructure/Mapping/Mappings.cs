using AutoMapper;
using Persons.Domain.Dtos;
using Persons.Domain.Entities;

namespace Persons.Infrastructure.Mapping
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<User, UserDto>()
                .ForMember(x => x.Scopes, opt => opt.MapFrom(j => j.Scopes.Select(x => x.Name).ToList()))
                .ReverseMap();
        }
    }
}
