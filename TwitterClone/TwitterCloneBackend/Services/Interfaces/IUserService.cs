using TwitterCloneBackend.Dto;
using TwitterCloneBackend.Models;

namespace TwitterCloneBackend.Services.Interfaces
{
    public interface IUserService
    {
        UserDto getById(int id);
        List<UserDto> getAll();
        UpdateDto updateUser(UpdateDto user);

    }
}
