using AutoMapper;
using TwitterCloneBackend.Dto;
using TwitterCloneBackend.Models;

namespace TwitterCloneBackend.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
